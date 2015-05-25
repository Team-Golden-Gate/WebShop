namespace GoldenGateShop.Data
{
    using System.Data.Entity;

    using GoldenGateShop.Models;

    public interface IShopDbContext
    {
        IDbSet<Cart> Carts { get; }

        IDbSet<Category> Categories { get; }

        IDbSet<Characteristic> Characteristics { get; }

        IDbSet<GlobalPromotion> GlobalPromotions { get; }

        IDbSet<IndividualPromotion> IndividualPromotions { get; }

        IDbSet<Order> Orders { get; }

        IDbSet<Product> Products { get; }

        IDbSet<ProductCharacteristic> ProductCharacteristics { get; }

        IDbSet<Promotion> Promotions { get; }

        IDbSet<State> States { get; }

        IDbSet<SubCategory> SubCategories { get; }

        IDbSet<Trade> Trades { get; }

        int SaveChanges();
    }
}
