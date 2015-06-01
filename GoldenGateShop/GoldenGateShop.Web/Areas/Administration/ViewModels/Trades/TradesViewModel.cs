namespace GoldenGateShop.Web.Areas.Administration.ViewModels.Trades
{
    using GoldenGateShop.Models;
    using GoldenGateShop.Web.Infrastructure.Mapping;

    public class TradesViewModel : IMapFrom<Trade>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Position { get; set; }
    }
}