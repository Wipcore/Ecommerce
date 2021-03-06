﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Kooboo.Commerce.API
{
    /// <summary>
    /// common query interface for commerce objects
    /// a common query should support fluent chain. see sample codes:
    /// sample code of fluent chain:
    /// var commerce = CreateCommerceInstanceSomewhere();
    /// var products = commerce.Products.ById(3).ByBrandId(4).ByName('mobile').Pagination(1, 50);
    /// or you can create query first:
    /// var query = commerce.Products.Query();
    /// query = query.ById(3);
    /// query = query.ByBrandId(4);
    /// query = query.ByName('mobile');
    /// var products = query.Pagination(1, 50);
    /// </summary>
    /// <typeparam name="T">commerce object</typeparam>
    public interface ICommerceQuery<T> where T : IItemResource
    {
        ICommerceQuery<T> Include(string property);

        ICommerceQuery<T> Include<TProperty>(Expression<Func<T, TProperty>> property);
        /// <summary>
        /// pagination the query result
        /// </summary>
        /// <param name="pageIndex">current page index</param>
        /// <param name="pageSize">page size</param>
        /// <returns>paged query result</returns>
        IListResource<T> Pagination(int pageIndex, int pageSize);
        /// <summary>
        /// get the first commerce object of the query. returns null if the query result is empty.
        /// </summary>
        /// <returns>commerce object</returns>
        T FirstOrDefault();
        /// <summary>
        /// get all commerce objects of the query
        /// </summary>
        /// <returns>commerce objects</returns>
        IListResource<T> ToArray();
        /// <summary>
        /// get total count of the query
        /// </summary>
        /// <returns>count of commerce objects</returns>
        int Count();
        /// <summary>
        /// query data without requesting hal links to save time
        /// </summary>
        ICommerceQuery<T> WithoutHalLinks();
        /// <summary>
        /// set hal parameter value
        /// </summary>
        /// <param name="name">hal parameter name</param>
        /// <param name="value">hal parameter value</param>
        ICommerceQuery<T> SetHalParameter(string name, object value);
    }
}
