﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCom.Web.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual Category Category { get; set; }
    }
}