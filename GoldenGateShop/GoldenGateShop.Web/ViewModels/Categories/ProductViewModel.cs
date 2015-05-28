namespace GoldenGateShop.Web.ViewModels.Categories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using GoldenGateShop.Models;

    public class ProductViewModel
    {
        public static Expression<Func<Product, ProductViewModel>> FromProduct
        {
            get
            {
                return p => new ProductViewModel()
                {
                    Id = p.Id,
                    CreatedAt = p.CreatedAt,
                    Name = p.Name,
                    Picture = p.Picture,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Trade = p.Trade.Name,
                    ProductCharacteristics = p.ProductCharacteristics
                    .AsQueryable()
                    .OrderBy(c=>c.CharacteristicType.Position)
                    .Select(ProductCharacteristicsDataModel.FromCharacteristics)
                    .ToList()
                };
            }
        }
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Trade { get; set; }

        public System.Collections.Generic.List<ProductCharacteristicsDataModel> ProductCharacteristics { get; set; }
    }
}