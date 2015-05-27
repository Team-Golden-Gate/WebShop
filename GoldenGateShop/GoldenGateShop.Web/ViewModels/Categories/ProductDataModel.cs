namespace GoldenGateShop.Web.ViewModels.Categories
{
    using GoldenGateShop.Models;
    using System;
    using System.Linq.Expressions;
    using System.Linq;
    using System.Collections.Generic;

    public class ProductDataModel
    {
        public static Expression<Func<Product, ProductDataModel>> FromProduct
        {
            get
            {
                return p => new ProductDataModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Picture = p.Picture,
                    Price = p.Price,
                    Category = p.Category.Name,
                    Characteristics = p.ProductCharacteristics
                        .AsQueryable()
                        .OrderBy(c => c.CharacteristicType.Position)
                        .Select(ProductCharacteristicsDataModel.FromCharacteristics)
                        .Take(5)
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public IEnumerable<ProductCharacteristicsDataModel> Characteristics { get; set; }
    }
}
