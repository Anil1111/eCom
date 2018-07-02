using eCom.Web.Entities;
using eCom.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCom.Web.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            context.Categories.Add(category);
            context.SaveChanges();

            return View();
        }
    }
}