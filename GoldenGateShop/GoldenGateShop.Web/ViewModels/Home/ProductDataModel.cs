
namespace GoldenGateShop.Web.ViewModels.Home
{
    using GoldenGateShop.Models;
    using System;
    using System.Linq.Expressions;

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
                    Description = p.Description
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }
    }
}
