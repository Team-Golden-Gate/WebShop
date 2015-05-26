namespace GoldenGateShop.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    public class CategoryViewModel
    {
        public IEnumerable<TradeDataModel> Trades { get; set; }
        public IEnumerable<ProductDataModel> Products { get; set; }
    }
}