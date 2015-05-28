namespace GoldenGateShop.Web.ViewModels.Categories
{
    using System;
    using System.Linq.Expressions;

    using GoldenGateShop.Models;

    public class ProductCharacteristicsDataModel
    {
        public static Expression<Func<ProductCharacteristic, ProductCharacteristicsDataModel>> FromCharacteristics
        {
            get
            {
                return x => new ProductCharacteristicsDataModel()
                {
                    Name = x.CharacteristicType.Name,
                    Description = x.CharacteristicValue.Description,
                    FilterType = x.CharacteristicType.FilterType.ToString()
                };
            }
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string FilterType { get; set; }
    }
}