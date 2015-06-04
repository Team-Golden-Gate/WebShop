namespace GoldenGateShop.Web.Areas.Administration.ViewModels.Trades
{
    using System.ComponentModel.DataAnnotations;

    using GoldenGateShop.Models;
    using GoldenGateShop.Web.Infrastructure.Mapping;

    public class TradesViewModel : IMapFrom<Trade>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Position { get; set; }
    }
}