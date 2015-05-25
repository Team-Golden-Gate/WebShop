namespace GoldenGateShop.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using GoldenGateShop.Models;
    using GoldenGateShop.Data.Migrations;


    public class ShopDbContext : IdentityDbContext<User>, IShopDbContext
    {
        public ShopDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopDbContext, Configuration>());
        }

        public IDbSet<Cart> Carts { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Characteristic> Characteristics { get; set; }

        public IDbSet<GlobalPromotion> GlobalPromotions { get; set; }

        public IDbSet<IndividualPromotion> IndividualPromotions { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<ProductCharacteristic> ProductCharacteristics { get; set; }

        public IDbSet<Promotion> Promotions { get; set; }

        public IDbSet<State> States { get; set; }     

        public IDbSet<Trade> Trades { get; set; }
    }
}
