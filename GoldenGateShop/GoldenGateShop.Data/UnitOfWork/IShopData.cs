
namespace GoldenGateShop.Data.UnitOfWork
{
    using GoldenGateShop.Data.Repositories;
    using GoldenGateShop.Models;

    public interface IShopData
    {
        IRepository<User> Users { get; }

        IRepository<Cart> Carts { get; }

        IRepository<Category> Categories { get; }

        IRepository<Characteristic> Characteristics { get; }

        IRepository<GlobalPromotion> GlobalPromotions { get; }

        IRepository<IndividualPromotion> IndividualPromotions { get; }

        IRepository<Order> Orders { get; }

        IRepository<Product> Products { get; }

        IRepository<ProductCharacteristic> ProductCharacteristics { get; }

        IRepository<Promotion> Promotions { get; }

        IRepository<State> States { get; }      

        IRepository<Trade> Trades { get; }

        int SaveChanges();
    }
}
