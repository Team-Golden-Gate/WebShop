namespace GoldenGateShop.Web.Areas.Administration.ViewModels.CharcacteristicTypes
{

    using GoldenGateShop.Models;
    using GoldenGateShop.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class CharacteristicTypesViewModel : IMapFrom<CharacteristicType>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        public FilterType FilterType { get; set; }
    }
}