namespace GoldenGateShop.Web.ViewModels.Categories
{
    using GoldenGateShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;


    public class ProductCharacteristicsDataModel
    {
        public static Expression<Func<ProductCharacteristic, ProductCharacteristicsDataModel>> FromCharacteristics
        {
            get
            {
                return x => new ProductCharacteristicsDataModel()
                {
                    Name = x.CharacteristicType.Name,
                    Description = x.CharacteristicValue.Description
                };
            }
        }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}