namespace GoldenGateShop.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Net;
    using GoldenGateShop.Web.ViewModels.Categories;

    public class CategoriesController : BaseController
    {
        // GET: Categories
        public ActionResult Index(string categoryName)
        {
            this.ViewBag.categoryName = categoryName;

            var isCategoryExists = this.Data.Categories.All()
                .Where(c => c.Name == categoryName)
                .Any();

            if (!isCategoryExists)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var trades = this.Data.Trades.All()
                .Where(t => t.Products.Any(p => p.Category.Name == categoryName))
                .OrderBy(t => t.Position)
                .Select(TradeDataModel.FromTrade)
                .ToList();

            var model = new CategoryViewModel()
            {
                Trades = trades,
            };

            return View(model);
        }

        public ActionResult Product(string categoryName, string productName)
        {
            this.ViewBag.categoryName = categoryName;
            this.ViewBag.productName = productName;

            return View();
        }
    }
}