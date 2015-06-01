namespace GoldenGateShop.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using GoldenGateShop.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        // [OutputCache(Duration=15*60)]
        public ActionResult Index()
        {
            var carouselProducts = this.Data.Products.All()
                .OrderByDescending(p => p.Id)
                .Select(ProductDataModel.FromProduct)
                .Take(3)
                .ToList();

            var promotionProducts = this.Data.Products.All()
                .OrderByDescending(p => p.Id)
                .Select(ProductDataModel.FromProduct)
                 .Take(12);

            var newestProducts = this.Data.Products.All()
                .OrderByDescending(p => p.Id)
                .Select(ProductDataModel.FromProduct)
                .Take(12)
                .ToList();

            var randomProducts = this.Data.Products.All()
                .OrderByDescending(p => p.Id)
                .Select(ProductDataModel.FromProduct)
                .Take(12)
                .ToList();

            var viewModel = new HomeViewModel()
            {
                CarouselProducts = carouselProducts,
                NewestProducts = newestProducts,
                PromotionProducts = promotionProducts,
                RandomProducts = randomProducts
            };

            this.ViewBag.Location = "Index";
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            this.ViewBag.Location = "About";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            this.ViewBag.Location = "Contact";
            return View();
        }

        [ChildActionOnly]
        // [OutputCache(Duration=15*60)]
        public ActionResult Menu()
        {
            var categories = this.Data.Categories.All()
                .OrderBy(c => c.Position)
                .Select(c => c.Name);

            return this.PartialView("_Menu", categories);
        }
    }
}