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
        public ActionResult Index(string Search, int pageNo)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            List<Category> categories;

            if (string.IsNullOrEmpty(Search))
            {
                categories = context.Categories.ToList();
            }
            else
            {
                categories = context.Categories.Where(x => x.Name.Contains(Search)).ToList();
            }

            categories.Take(10);

            return View(categories);
        }
        
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

            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int ID)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var category = context.Categories.Find(ID);

            return View(category);
        }


        [HttpPost]
        public ActionResult Edit(Category category)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            context.Entry(category).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            context.Entry(category).State = System.Data.Entity.EntityState.Deleted;

            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}