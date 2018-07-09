using eCom.Web.Entities;
using eCom.Web.Models;
using eCom.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCom.Web.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index(string Search, int? pageNo, int? items)
        {
            pageNo = !pageNo.HasValue ? 1 : pageNo.Value;
            items = !items.HasValue ? 10 : items.Value;

            ApplicationDbContext context = new ApplicationDbContext();

            CategoriesListViewModel model = new CategoriesListViewModel();
            
            if (string.IsNullOrEmpty(Search))
            {
                model.Categories = context.Categories.ToList();
            }
            else
            {
                model.Categories = context.Categories.Where(x => x.Name.Contains(Search)).ToList();
            }

            model.Categories = model.Categories.Skip((pageNo.Value - 1) * items.Value).Take(items.Value).ToList();

            model.Pager = new Pager(context.Categories.Count(), pageNo, items.Value);

            return View(model);
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

            var cat = context.Categories.Find(category.ID);

            var products = context.Products.Where(p => p.Category.ID == cat.ID).ToList();

            context.Products.RemoveRange(products);

            context.Categories.Remove(cat);

            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}