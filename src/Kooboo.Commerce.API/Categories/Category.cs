﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.API.Categories
{
    /// <summary>
    /// category api object, mostly product category
    /// </summary>
    public class Category : ItemResource
    {
        /// <summary>
        /// category id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// category name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// category description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// category photo image file path
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// is the category published? only published categories need to be shown on the front-site
        /// </summary>
        public bool Published { get; set; }
        /// <summary>
        /// parent category
        /// </summary>
        public Category Parent { get; set; }
        /// <summary>
        /// children categories
        /// </summary>
        public Category[] Children { get; set; }
    }
}
