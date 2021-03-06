﻿using Kooboo.CMS.Common.Runtime.Dependency;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Kooboo.Commerce.API.HAL.Persistence
{
    [Dependency(typeof(IResourceLinkPersistence), ComponentLifeStyle.Singleton)]
    public class FileResourceLinkPersistence : IResourceLinkPersistence
    {
        private readonly object _loadLock = new object();
        private Dictionary<string, ResourceLink> _linksById;
        private Dictionary<string, List<ResourceLink>> _linksByResource;
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

        public string FilePath { get; private set; }

        public FileResourceLinkPersistence()
            : this(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data\\Commerce\\HALLinks.json"))
        {
        }

        public FileResourceLinkPersistence(string filePath)
        {
            if (String.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path is required.", "filePath");

            FilePath = filePath;
        }

        public void Save(ResourceLink link)
        {
            if (link == null)
                throw new ArgumentNullException("link");

            if (String.IsNullOrWhiteSpace(link.SourceResourceName))
                throw new ArgumentException("Source resource name must be set.");

            if (String.IsNullOrWhiteSpace(link.DestinationResourceName))
                throw new ArgumentException("Destination resource name must be set.");

            EnsureCacheLoaded();

            _lock.EnterWriteLock();

            try
            {
                ResourceLink oldLink = null;

                if (!String.IsNullOrEmpty(link.Id) && _linksById.TryGetValue(link.Id, out oldLink))
                {
                    var allLinks = _linksById.Values.ToList();
                    allLinks.Remove(oldLink);
                    allLinks.Add(link);

                    Flush(allLinks);
                    // Update cache
                    link.CopyTo(oldLink);
                }
                else
                {
                    var newLink = link.Clone();
                    var allLinks = _linksById.Values.ToList();
                    allLinks.Add(newLink);

                    Flush(allLinks);

                    // Update cache
                    _linksById.Add(newLink.Id, newLink);

                    if (!_linksByResource.ContainsKey(newLink.SourceResourceName))
                    {
                        _linksByResource.Add(newLink.SourceResourceName, new List<ResourceLink>());
                    }

                    _linksByResource[newLink.SourceResourceName].Add(newLink);
                }
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public void Delete(string linkId)
        {
            EnsureCacheLoaded();

            _lock.EnterWriteLock();

            try
            {
                ResourceLink oldLink = null;

                if (_linksById.TryGetValue(linkId, out oldLink))
                {
                    var allLinks = _linksById.Values.ToList();
                    allLinks.Remove(oldLink);

                    Flush(allLinks);

                    // Update cache
                    _linksById.Remove(linkId);
                    _linksByResource[oldLink.SourceResourceName].Remove(oldLink);
                }
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public IEnumerable<ResourceLink> GetLinks(string resourceName)
        {
            EnsureCacheLoaded();

            _lock.EnterReadLock();

            try
            {
                List<ResourceLink> links = null;
                if (_linksByResource.TryGetValue(resourceName, out links))
                {
                    return links.Select(x => x.Clone()).ToList();
                }

                return Enumerable.Empty<ResourceLink>();
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public ResourceLink GetById(string linkId)
        {
            EnsureCacheLoaded();

            _lock.EnterReadLock();

            try
            {
                ResourceLink link = null;
                if (_linksById.TryGetValue(linkId, out link))
                {
                    return link.Clone();
                }
                return null;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        private void EnsureCacheLoaded()
        {
            if (_linksById == null)
            {
                lock (_loadLock)
                {
                    if (_linksById == null)
                    {
                        var linksById = new Dictionary<string, ResourceLink>();
                        var linksByResource = new Dictionary<string, List<ResourceLink>>();

                        var allLinks = ReadLinks();

                        foreach (var link in allLinks)
                        {
                            linksById.Add(link.Id, link);

                            if (!linksByResource.ContainsKey(link.SourceResourceName))
                            {
                                linksByResource.Add(link.SourceResourceName, new List<ResourceLink>());
                            }

                            linksByResource[link.SourceResourceName].Add(link);
                        }

                        _linksById = linksById;
                        _linksByResource = linksByResource;
                    }
                }
            }
        }

        private List<ResourceLink> ReadLinks()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath, Encoding.UTF8);
                return JsonConvert.DeserializeObject<List<ResourceLink>>(json);
            }

            return new List<ResourceLink>();
        }

        private void Flush(IEnumerable<ResourceLink> links)
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(links));
        }
    }
}
