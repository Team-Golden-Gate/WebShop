namespace GoldenGateShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    using GoldenGateShop.Models;
    using GoldenGateShop.Data.Migrations;
    using GoldenGateShop.Contracts;


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

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }


        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                        entity.ModifiedOn = DateTime.Now;
                        if (entity is IDeletableEntity)
                        {
                           var delitableEntity = (IDeletableEntity)entry.Entity;
                           delitableEntity.DeletedOn = DateTime.Now;
                        }
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private void ApplyDeletableEntityRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (
                var entry in
                    this.ChangeTracker.Entries()
                        .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
