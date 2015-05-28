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

        public ActionResult Index()
        {
            var categories = this.Data.Categories.All()
                .OrderBy(c => c.Position)
                .Select(c => c.Name)
                .ToList();

            return this.View(categories);
        }
        public ActionResult Category(string categoryName, GetProductsBindingModel model)
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

            if (productRange.Any())
            {
                this.ViewBag.MinPrice = productRange.Min(p => p.Price);
                this.ViewBag.MaxPrice = productRange.Max(p => p.Price);
            }
            else
            {
                this.ViewBag.MinPrice = 0;
                this.ViewBag.MaxPrice = 0;
            }

            var data = new CategoryViewModel()
            {
                Trades = trades,
            };

            this.ViewBag.Location = categoryName;
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

        public ActionResult GetFilters(string categoryName)
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

            var data = this.Data.Characteristics.All()
                .Where(c => c.FilterType != FilterType.None)
                .Where(c => c.Category.Any(cat => cat.Name == categoryName))
                .Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name,
                    FilterType = c.FilterType,
                    Values = c.CharacteristicValue.AsQueryable()
                    .Select(CharacteristicValueDataModel.FromCharacteristicsValue)
                    .ToList(),
                    Min = c.CharacteristicValue.AsQueryable()
                    .Where(x => x.ProductCharacteristics
                        .Any(t => t.Product.Category.Name == categoryName))
                    .Min(x => x.Value),
                    Max = c.CharacteristicValue.AsQueryable()
                     .Where(x => x.ProductCharacteristics
                        .Any(t => t.Product.Category.Name == categoryName))
                    .Max(x => x.Value)

                })
                .ToList();

            var modelData = new List<CategoryCharacteristicsDataModel>();

            foreach (var item in data)
            {
                modelData.Add(new CategoryCharacteristicsDataModel()
                  {
                      Id = item.Id,
                      FilterType = item.FilterType,
                      Max = item.Max,
                      Min = item.Min,
                      Name = item.Name,
                      Values = item.Values
                  });
            }

            return this.PartialView("_GetFilters", modelData);
        }

        public ActionResult Product(string categoryName, string productName)
        {
            var isCategoryExists = this.Data.Categories.All()
              .Where(c => c.Name == categoryName)
              .Any();

            if (!isCategoryExists)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = this.Data.Products.All()
                .Where(p => p.Category.Name == categoryName && p.Name == productName)
                .Select(ProductViewModel.FromProduct)
                .FirstOrDefault();

            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            return this.View(product);
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

            if (model.Filters != null)
            {
                try
                {
                    var rangeFilters = model.Filters.Where(f => f.Contains("min"));
                    var cheackFilters = model.Filters.Where(f => f.Contains("check"));

                    foreach (var filter in rangeFilters)
                    {
                        var splitStr = filter.Split('_');
                        var characteristicType = splitStr[0].Replace("---", " "); //in the view was change, because mess with JS, here will turn it back, how is in the database
                        var min = int.Parse(splitStr[2]);
                        var max = int.Parse(splitStr[4]);

                        products = products
                            .Where(p => p.ProductCharacteristics
                                .Any(x => x.CharacteristicType.Name == characteristicType
                                    && x.CharacteristicValue.Value >= min
                                    && x.CharacteristicValue.Value <= max));
                    }

                    var checkFilters = new List<FilterBindingModel>();
                    foreach (var filter in cheackFilters)
                    {
                        var splitStr = filter.Split('_');
                        var characteristicTypeId = int.Parse(splitStr[1]);
                        var characteristicValueId = int.Parse(splitStr[2]);


                        checkFilters.Add(new FilterBindingModel()
                        {
                            characteristicTypeId = characteristicTypeId,
                            characteristicValueId = characteristicValueId
                        });
                    }

                    var checkFiltersGroups = checkFilters
                        .GroupBy(c => c.characteristicTypeId)
                        .Select(g => new { g.Key, Elements = g });

                    foreach (var group in checkFiltersGroups)
                    {
                        var searchPredicate = PredicateBuilder.False<Product>();

                        foreach (var filter in group.Elements)
                        {
                            var closureCharacteristicTypeId = filter.characteristicTypeId;
                            var closureCharacteristicValueId = filter.characteristicValueId;

                            searchPredicate =
                              searchPredicate.Or(p => p.ProductCharacteristics
                                .Any(c => c.CharacteristicTypeId == closureCharacteristicTypeId
                                    && c.CharacteristicValueId == closureCharacteristicValueId));

                        }

                        products = products.AsExpandable().Where(searchPredicate);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
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