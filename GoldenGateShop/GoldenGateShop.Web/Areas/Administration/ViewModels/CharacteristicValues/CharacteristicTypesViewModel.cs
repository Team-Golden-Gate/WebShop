namespace GoldenGateShop.Web.Areas.Administration.ViewModels.CharacteristicValues
{
    using GoldenGateShop.Models;
    using GoldenGateShop.Web.Infrastructure.Mapping;

    public class CharacteristicTypesViewModel : IMapFrom<CharacteristicType>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}