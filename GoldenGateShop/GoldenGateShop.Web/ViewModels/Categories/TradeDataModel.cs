namespace GoldenGateShop.Web.ViewModels.Categories
{
    using GoldenGateShop.Models;
    using System;
    using System.Linq.Expressions;

    public class TradeDataModel
    {
        public static Expression<Func<Trade, TradeDataModel>> FromTrade
        {
            get
            {
                return t => new TradeDataModel()
                {
                    Name = t.Name
                };
            }
        }

        public string Name { get; set; }
    }
}
