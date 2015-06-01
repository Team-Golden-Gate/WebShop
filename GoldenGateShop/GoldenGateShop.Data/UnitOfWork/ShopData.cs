namespace GoldenGateShop.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using GoldenGateShop.Data.Repositories;
    using GoldenGateShop.Models;

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

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
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
                return this.GetRepository<Category>();
            }
        }

        public IRepository<CharacteristicType> CharacteristicTypes
        {
            get
            {
                return this.GetRepository<CharacteristicType>();
            }
        }

        public IRepository<CharacteristicValue> CharacteristicValues
        {
            get
            {
                return this.GetRepository<CharacteristicValue>();
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
                return this.GetRepository<Product>();
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
                return this.GetRepository<Trade>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
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
    }
}
