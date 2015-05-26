namespace GoldenGateShop.Web.ViewModels.Categories
{
    using GoldenGateShop.Models;
    using System;
    using System.Linq.Expressions;
    using System.Linq;

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
                    Description = p.ProductCharacteristics
                        .AsQueryable()
                        .Where(c => c.CharacteristicType.Name == "Short Description")
                        .Select(c => c.CharacteristicValue.Description),
                    Characteristics = p.ProductCharacteristics
                        .AsQueryable()
                        .OrderBy(c => c.CharacteristicType.Position)
                        .Select(ProductCharacteristicsDataModel.FromCharacteristics)
                        .Take(4)

                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public IQueryable<string> Description { get; set; }

        public IQueryable<ProductCharacteristicsDataModel> Characteristics { get; set; }
    }
}
