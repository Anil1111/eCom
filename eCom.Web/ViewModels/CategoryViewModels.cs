using eCom.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCom.Web.ViewModels
{
    public class CategoriesListViewModel  : BaseListViewModel
    {
        public List<Category> Categories { get; set; }
    }
}