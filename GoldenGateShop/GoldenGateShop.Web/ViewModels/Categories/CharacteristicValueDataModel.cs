namespace GoldenGateShop.Web.ViewModels.Categories
{
    using System;
    using System.Linq.Expressions;
    using System.Linq;
    using System.Collections.Generic;

    using GoldenGateShop.Models;


    public class CharacteristicValueDataModel
    {
        public static Expression<Func<CharacteristicValue, CharacteristicValueDataModel>> FromCharacteristicsValue
        {
            get
            {
                return x => new CharacteristicValueDataModel()
                {
                    Id = x.Id,
                    Description = x.Description,
                    Value = x.Value

                };
            }
        }

        public string Description { get; set; }

        public double? Value { get; set; }

        public int Id { get; set; }
    }
}