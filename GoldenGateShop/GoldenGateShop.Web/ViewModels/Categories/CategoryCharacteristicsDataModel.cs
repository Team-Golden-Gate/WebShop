namespace GoldenGateShop.Web.ViewModels.Categories
{
    using System;
    using System.Linq.Expressions;
    using GoldenGateShop.Models;
    using System.Linq;
    using System.Collections.Generic;

    public class CategoryCharacteristicsDataModel
    {
        public static Expression<Func<CharacteristicType, CategoryCharacteristicsDataModel>> FromCharacteristicType
        {
            get
            {
                return c => new CategoryCharacteristicsDataModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    FilterType = c.FilterType,
                    Values = c.CharacteristicValue.AsQueryable()
                    .Select(CharacteristicValueDataModel.FromCharacteristicsValue)
                    .ToList(),
                    Min = c.CharacteristicValue.AsQueryable().Min(x => x.Value),
                    Max = c.CharacteristicValue.AsQueryable().Min(x => x.Value),

                };
            }
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public FilterType FilterType { get; set; }

        public List<CharacteristicValueDataModel> Values { get; set; }

        public double? Min { get; set; }

        public double? Max { get; set; }        
    }
}