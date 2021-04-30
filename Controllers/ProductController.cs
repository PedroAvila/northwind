using NorthWind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthWind.Controllers
{
    public class ProductController : Controller
    {
        [ChildActionOnly]
        public ActionResult Total()
        {
            var context = new NorthwindEntities1();
            var result = $"<strong>{context.Products.Count()} productos</strong> ";
            return Content(result);
        }

        public ActionResult HacerAlgoSinRespuesta()
        {
            return new EmptyResult();
        }
        
        public ActionResult NoAutorizado()
        {
            return new HttpUnauthorizedResult("Acceso denegado");
        }

        public ActionResult Create()
        {
            var newProduct = new Product();
            var context = new NorthwindEntities1();
            var categories = context.Categories.Select(c => new { c.CategoryID, c.CategoryName });
            ViewBag.CategoryID = new SelectList(categories, "CategoryID", "CategoryName");
            return View(newProduct);
        }

        [HttpPost]
        public ActionResult Create(Product newProduct)
        {
            ActionResult result;
            if (ModelState.IsValid)
            {
                var context = new NorthwindEntities1();
                context.Products.Add(newProduct);
                context.SaveChanges();
                result = RedirectToAction("Details", new { id = newProduct.ProductID });
            }
            else
            {
                result = View(newProduct);
            }

            return result;
        }

        // GET: Product
        public ActionResult Index()
        {
            var context = new Models.NorthwindEntities1();
            return View(context.Products.ToList());
        }

        public ActionResult Details(int id)
        {
            ActionResult result;
            var context = new NorthwindEntities1();
            var product = context.Products.FirstOrDefault(p => p.ProductID == id);
            if(product != null)
            {
                result = View(product);
            }
            else
            {
                result = HttpNotFound("Producto no encontrado");
            }

            return result;
        }
    }
}