namespace GoldenGateShop.Data
{
    using System.Data.Entity;

    using GoldenGateShop.Models;
    using System.Data.Entity.Infrastructure;

    public interface IShopDbContext
    {
        IDbSet<Cart> Carts { get; }

        IDbSet<Category> Categories { get; }

        IDbSet<CharacteristicType> CharacteristicTypes { get; }

        IDbSet<CharacteristicValue> CharacteristicValues { get; }

        IDbSet<GlobalPromotion> GlobalPromotions { get; }

        IDbSet<IndividualPromotion> IndividualPromotions { get; }

        IDbSet<Order> Orders { get; }

        IDbSet<Product> Products { get; }

        IDbSet<ProductCharacteristic> ProductCharacteristics { get; }

        IDbSet<Promotion> Promotions { get; }

        IDbSet<State> States { get; }

        IDbSet<Trade> Trades { get; }

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
