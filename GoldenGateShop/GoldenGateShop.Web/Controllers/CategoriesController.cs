namespace GoldenGateShop.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Net;

    using LinqKit;

    using GoldenGateShop.Web.ViewModels.Categories;
    using GoldenGateShop.Web.BindingModels;
    using GoldenGateShop.Models;

    public class CategoriesController : BaseController
    {
        private const int PageSize = 3;
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

            var products = this.FilterProducts(categoryName, model);

            this.ViewBag.ProductCount = products.Count();
            this.ViewBag.PageSize = PageSize;

            var productRange = this.Data.Products.All()
                .Where(p => p.Category.Name == categoryName);

            this.ViewBag.MinPrice = productRange.Min(p => p.Price);
            this.ViewBag.MaxPrice = productRange.Max(p => p.Price);

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

            var products = this.FilterProducts(categoryName, model);

            var skip = page * model.PageSize;
            var data = products
                 .Skip(skip)
                 .Take(model.PageSize)
                 .ToList();

            this.ViewBag.ProductCount = products.Count();
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

            if (model.TradeNames != null)
            {
                // http://stackoverflow.com/questions/782339/how-to-dynamically-add-or-operator-to-where-clause-in-linq
                var searchPredicate = PredicateBuilder.False<Product>();

                foreach (var name in model.TradeNames)
                {
                    var closureVariable = name;
                    searchPredicate =
                      searchPredicate.Or(p => p.Trade.Name == closureVariable);
                }

                products = products.AsExpandable().Where(searchPredicate);
            }

            if (model.MinPrice.HasValue)
            {
                products = products.Where(p => p.Price >= model.MinPrice.Value);
            }

            if (model.MaxPrice.HasValue)
            {
                products = products.Where(p => p.Price <= model.MaxPrice.Value);
            }

            if (model.OrderBy != null)
            {
                if (model.OrderBy == "By price asc")
                {
                    products = products.OrderBy(p => p.Price);
                }
                else if (model.OrderBy == "By price desc")
                {
                    products = products.OrderByDescending(p => p.Price);
                }
                else if (model.OrderBy == "Newest")
                {
                    products = products.OrderByDescending(p => p.Id);
                }
                else if (model.OrderBy == "Promotion")
                {
                    //TODO:
                    products = products.OrderBy(p => p.Price);
                }
            }
            else
            {
                products = products.OrderBy(p => p.Price);
            }


            var productsModel = products.Select(ProductDataModel.FromProduct);

            return productsModel;
        }
    }
}