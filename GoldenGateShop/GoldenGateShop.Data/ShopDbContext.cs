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

        public IDbSet<CharacteristicType> CharacteristicTypes { get; set; }

        public IDbSet<GlobalPromotion> GlobalPromotions { get; set; }

        public IDbSet<IndividualPromotion> IndividualPromotions { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<ProductCharacteristic> ProductCharacteristics { get; set; }

        public IDbSet<Promotion> Promotions { get; set; }

        public IDbSet<State> States { get; set; }

        public IDbSet<Trade> Trades { get; set; }

        public IDbSet<CharacteristicValue> CharacteristicValues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacteristicType>()
                .HasMany(c => c.CharacteristicValue)
                .WithRequired(c => c.CharacteristicType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CharacteristicType>()
                .HasMany(c => c.ProductCharacteristics)
                .WithRequired(c => c.CharacteristicType)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Category>()
               .HasMany(c => c.CharacteristicTypes)
               .WithMany(c => c.Category);

            modelBuilder.Entity<ProductCharacteristic>()
                .HasRequired(c => c.Product)
                .WithMany(c => c.ProductCharacteristics)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCharacteristic>()
                .HasRequired(c => c.CharacteristicValue)
                .WithMany(c => c.ProductCharacteristics)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCharacteristic>()
                .HasRequired(c => c.CharacteristicType)
                .WithMany(c => c.ProductCharacteristics)
                .WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }
    }
}
