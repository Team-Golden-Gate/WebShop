namespace GoldenGateShop.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Net;

    using GoldenGateShop.Web.ViewModels.Categories;
    using GoldenGateShop.Web.BindingModels;

    public class CategoriesController : BaseController
    {
        private const int PageSize = 12;
        // GET: Categories
        public ActionResult Index(string categoryName, GetProductsBindingModel model)
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

            var productCount = this.FilterProducts(categoryName, model).Count();

            this.ViewBag.ProductCount = productCount;
            this.ViewBag.PageSize = PageSize;

            var data = new CategoryViewModel()
            {
                Trades = trades,
            };

            return this.View(data);
        }

        public ActionResult GetProducts(string categoryName, int page, GetProductsBindingModel model)
        {
            //if (!this.Request.IsAjaxRequest())
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            var isCategoryExists = this.Data.Categories.All()
              .Where(c => c.Name == categoryName)
              .Any();

            if (!isCategoryExists)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (model == null)
            {
                model = new GetProductsBindingModel();
            }

            if (model.PageSize == 0)
            {
                model.PageSize = PageSize;
            }

            var dataCount = this.FilterProducts(categoryName, model);

            var skip = page * model.PageSize;
            var data = dataCount
                 .Skip(skip)
                 .Take(model.PageSize)
                 .ToList();

            this.ViewBag.ProductCount = dataCount.Count();
            this.ViewBag.PageSize = PageSize;

            return this.PartialView("_GetProducts", data);
        }

        public ActionResult Product(string categoryName, string productName)
        {
            this.ViewBag.categoryName = categoryName;
            this.ViewBag.productName = productName;

            return this.View();
        }

        [NonAction]
        public IQueryable<ProductDataModel> FilterProducts(string categoryName, GetProductsBindingModel model)
        {
            var products = this.Data.Products.All()
                 .Where(p => p.Category.Name == categoryName);

            if (model.TradeName != null)
            {
                products = products.Where(p => p.Trade.Name == model.TradeName);
            }

            if (model.MinPrice.HasValue)
            {
                products = products.Where(p => p.Price >= model.MinPrice.Value);
            }

            if (model.MaxPrice.HasValue)
            {
                products = products.Where(p => p.Price <= model.MaxPrice.Value);
            }

            var productsModel = products.OrderBy(p => p.Price)
                 .Select(ProductDataModel.FromProduct);

            return productsModel;
        }
    }
}