namespace GoldenGateShop.Web.Areas.Administration.ViewModels.CharcacteristicTypes
{

    using GoldenGateShop.Models;
    using GoldenGateShop.Web.Infrastructure.Mapping;

    public class CharacteristicTypesViewModel : IMapFrom<CharacteristicType>
    {
        public int Id { get; set; }
      
        public string Name { get; set; }

        public int Position { get; set; }

        public FilterType FilterType { get; set; }
    }
}