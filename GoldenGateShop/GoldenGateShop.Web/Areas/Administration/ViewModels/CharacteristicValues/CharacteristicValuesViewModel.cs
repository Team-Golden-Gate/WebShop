namespace GoldenGateShop.Web.Areas.Administration.ViewModels.CharacteristicValues
{
    using AutoMapper;
    using GoldenGateShop.Models;
    using GoldenGateShop.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class CharacteristicValuesViewModel : IMapFrom<CharacteristicValue>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public double? Value { get; set; }

        [Required]       
        public string Description { get; set; }

        public int CharacteristicTypeId { get; set; }

        public string CharacteristicTypeName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<CharacteristicValue, CharacteristicValuesViewModel>()
                .ForMember(m=>m.CharacteristicTypeName, opt => opt.MapFrom(u=>u.CharacteristicType.Name));
        }
    }
}