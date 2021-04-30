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