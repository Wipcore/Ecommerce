﻿using Kooboo.CMS.Common.Persistence.Non_Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Kooboo.Commerce.Settings;

namespace Kooboo.Commerce.ImageSizes
{
    /// <summary>
    /// Predefined the image size that can be generated for each products. 
    /// Different size of image can be queried like /image/small/imagename.jpg
    /// </summary>
    public class ImageSize
    {
        public string Name { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsMultiple { get; set; }
    }
}
