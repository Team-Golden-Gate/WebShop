﻿namespace GoldenGateShop.Web.Controllers
{
    using GoldenGateShop.Web.ViewModels.Home;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;


    public class HomeController : BaseController
    {
        [OutputCache(Duration=15*60)]
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


            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}