﻿using Kooboo.Commerce.API.Categories;
using Kooboo.Commerce.Categories.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.CMS.Common.Runtime.Dependency;
using Kooboo.Commerce.API.HAL;

namespace Kooboo.Commerce.API.LocalProvider.Categories
{
    /// <summary>
    /// category api
    /// </summary>
    [Dependency(typeof(ICategoryAPI), ComponentLifeStyle.Transient)]
    [Dependency(typeof(ICategoryQuery), ComponentLifeStyle.Transient)]
    public class CategoryAPI : LocalCommerceQuery<Category, Kooboo.Commerce.Categories.Category>, ICategoryAPI
    {
        private ICategoryService _categoryService;

        public CategoryAPI(IHalWrapper halWrapper, ICategoryService categoryService, IMapper<Category, Kooboo.Commerce.Categories.Category> mapper)
            : base(halWrapper, mapper)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// create entity query
        /// </summary>
        /// <returns>queryable object</returns>
        protected override IQueryable<Commerce.Categories.Category> CreateQuery()
        {
            return _categoryService.Query();
        }

        /// <summary>
        /// use the default order when pagination the query
        /// </summary>
        /// <param name="query">pagination query</param>
        /// <returns>ordered query</returns>
        protected override IQueryable<Commerce.Categories.Category> OrderByDefault(IQueryable<Commerce.Categories.Category> query)
        {
            return query.OrderBy(o => o.Id);
        }

        /// <summary>
        /// map the entity to object
        /// </summary>
        /// <param name="obj">entity</param>
        /// <returns>object</returns>

        /// <summary>
        /// add id filter to query
        /// </summary>
        /// <param name="id">category id</param>
        /// <returns>category query</returns>
        public ICategoryQuery ById(int id)
        {
            EnsureQuery();
            _query = _query.Where(o => o.Id == id).OrderBy(o => o.Name);
            return this;
        }

        /// <summary>
        /// add name filter to query
        /// </summary>
        /// <param name="name">category name</param>
        /// <returns>category query</returns>
        public ICategoryQuery ByName(string name)
        {
            EnsureQuery();
            _query = _query.Where(o => o.Name == name);
            return this;
        }

        /// <summary>
        /// add published filter to query
        /// normally the api doesn't set the published as implicted. you need to explicit add this filter at the front-site.
        /// </summary>
        /// <param name="published">category id</param>
        /// <returns>category query</returns>
        public ICategoryQuery Published(bool published)
        {
            EnsureQuery();
            _query = _query.Where(o => o.Published == published);
            return this;
        }

        /// <summary>
        /// add parent id filter to query
        /// </summary>
        /// <param name="parentId">category parent id</param>
        /// <returns>category query</returns>
        public ICategoryQuery ByParentId(int? parentId)
        {
            EnsureQuery();
            if (parentId.HasValue)
                _query = _query.Where(o => o.Parent.Id == parentId.Value);
            else
                _query = _query.Where(o => o.Parent == null);
            return this;
        }

        /// <summary>
        /// filter by custom field value
        /// </summary>
        /// <param name="customFieldName">custom field name</param>
        /// <param name="fieldValue">custom field valule</param>
        /// <returns>brand query</returns>
        public ICategoryQuery ByCustomField(string customFieldName, string fieldValue)
        {
            EnsureQuery();
            var customFieldQuery = _categoryService.CustomFieldsQuery().Where(o => o.Name == customFieldName && o.Value == fieldValue);
            _query = _query.Where(o => customFieldQuery.Any(c => c.CategoryId == o.Id));
            return this;
        }

        /// <summary>
        /// create category query 
        /// </summary>
        /// <returns>category query</returns>
        public ICategoryQuery Query()
        {
            return this;
        }
    }
}
