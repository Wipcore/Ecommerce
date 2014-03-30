﻿using Kooboo.Commerce.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kooboo.Commerce.WebAPI.Controllers
{
    /// <summary>
    /// commerce data access and query controller base
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CommerceAPIControllerAccessBase<T> : CommerceAPIControllerQueryBase<T>
    {
        /// <summary>
        /// create or save the api object
        /// </summary>
        /// <param name="obj">api object</param>
        /// <returns>true if successfully, else false</returns>
        [HttpPost]
        public virtual bool Post(T obj)
        {
            var accesser = GetAccesser();
            return accesser.Save(obj);
        }
        /// <summary>
        /// update the api object
        /// </summary>
        /// <param name="obj">api object</param>
        /// <returns>true if successfully, else false</returns>
        [HttpPut]
        public virtual bool Put(T obj)
        {
            var accesser = GetAccesser();
            return accesser.Update(obj);
        }
        /// <summary>
        /// delete the api object
        /// </summary>
        /// <param name="obj">api object</param>
        /// <returns>true if successfully, else false</returns>
        [HttpDelete]
        public virtual bool Delete(T obj)
        {
            var accesser = GetAccesser();
            return accesser.Delete(obj);
        }

        /// <summary>
        /// build the commerce query filters from query string.
        /// </summary>
        /// <returns>commerce query</returns>
        protected override ICommerceQuery<T> BuildQueryFromQueryStrings()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// get the commerce data access to manage the objects
        /// </summary>
        /// <returns>commerce data access</returns>
        protected abstract ICommerceAccess<T> GetAccesser();
    }
}