namespace GoldenGateShop.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class CategoriesController : BaseController
    {
        // GET: Categories
        public ActionResult Index(string categoryName, string productName)
        {
            this.ViewBag.categoryName = categoryName;
            this.ViewBag.productName = productName;

            return View();
        }

        public ActionResult Product(string categoryName, string productName)
        {
            this.ViewBag.categoryName = categoryName;
            this.ViewBag.productName = productName;

            return View();
        }
    }
}