namespace GoldenGateShop.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using GoldenGateShop.Data.Repositories;
    using GoldenGateShop.Models;
    using GoldenGateShop.Contracts;

    public class ShopData : IShopData
    {

        private DbContext context;
        private IDictionary<Type, object> repositories;

        public ShopData()
            : this(new ShopDbContext())
        {
        }
        public ShopData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }
        public IShopDbContext Context
        {
            get
            {
                return this.context as IShopDbContext;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetDeletableEntityRepository<User>();
            }
        }

        public IRepository<Cart> Carts
        {
            get
            {
                return this.GetRepository<Cart>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetDeletableEntityRepository<Category>();
            }
        }

        public IRepository<CharacteristicType> CharacteristicTypes
        {
            get
            {
                return this.GetDeletableEntityRepository<CharacteristicType>();
            }
        }

        public IRepository<CharacteristicValue> CharacteristicValues
        {
            get
            {
                return this.GetDeletableEntityRepository<CharacteristicValue>();
            }
        }


        public IRepository<GlobalPromotion> GlobalPromotions
        {
            get
            {
                return this.GetRepository<GlobalPromotion>();
            }
        }

        public IRepository<IndividualPromotion> IndividualPromotions
        {
            get
            {
                return this.GetRepository<IndividualPromotion>();
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                return this.GetRepository<Order>();
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                return this.GetDeletableEntityRepository<Product>();
            }
        }

        public IRepository<ProductCharacteristic> ProductCharacteristics
        {
            get
            {
                return this.GetRepository<ProductCharacteristic>();
            }
        }

        public IRepository<Promotion> Promotions
        {
            get
            {
                return this.GetRepository<Promotion>();
            }
        }

        public IRepository<State> States
        {
            get
            {
                return this.GetRepository<State>();
            }
        }

        public IRepository<Trade> Trades
        {
            get
            {
                return this.GetDeletableEntityRepository<Trade>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }


        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);

            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository =
                    Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
