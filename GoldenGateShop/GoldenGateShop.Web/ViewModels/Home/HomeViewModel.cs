namespace GoldenGateShop.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public IEnumerable<ProductDataModel> NewestProducts { get; set; }

        public IEnumerable<ProductDataModel> CarouselProducts { get; set; }

        public IEnumerable<ProductDataModel> PromotionProducts { get; set; }

        public IEnumerable<ProductDataModel> RandomProducts { get; set; }

    }
}