namespace GoldenGateShop.Web.ViewModels.Categories
{
    using System.Collections.Generic;
    using GoldenGateShop.Models;

    public class CategoryViewModel
    {
        public IEnumerable<TradeDataModel> Trades { get; set; }

        public IEnumerable<CategoryCharacteristicsDataModel> CategoryCharacteristics { get; set; }
    }
}