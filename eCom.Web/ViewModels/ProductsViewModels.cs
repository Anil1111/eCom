﻿using eCom.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCom.Web.ViewModels
{
    public class ProductsListViewModel : BaseListViewModel
    {
        public List<Product> Products { get; set; }
    }

    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }

        public List<Category> Categories { get; set; }
    }    
}