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
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            List<Product> products = context.Products.ToList();

            return View(products);
        }

        public ActionResult Create()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            
            ProductViewModel model = new ProductViewModel();
            
            model.Categories = context.Categories.ToList();

            return View("ProductOperation", model);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var product = new Product();

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Category = context.Categories.Find(model.CategoryID);

            context.Products.Add(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ID)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var product = context.Products.Find(ID);

            ProductViewModel model = new ProductViewModel();

            model.ID = product.ID;
            model.Name = product.Name;
            model.Description = product.Description;
            model.Price = product.Price;

            model.CategoryID = product.Category.ID;

            model.Categories = context.Categories.ToList();

            return View("ProductOperation", model);
        }
        
        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            
            var product = context.Products.Find(model.ID);

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Category = context.Categories.Find(model.CategoryID);
            
            context.Entry(product).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(Product product)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            context.Entry(product).State = System.Data.Entity.EntityState.Deleted;

            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}