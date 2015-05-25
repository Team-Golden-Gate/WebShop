namespace GoldenGateShop.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using GoldenGateShop.Models;


    internal sealed class Configuration : DbMigrationsConfiguration<ShopDbContext>
    {
        private Random random = new Random(0);

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ShopDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var users = this.SeedUsers(context);
            var categories = this.SeedCategories(context);
            var trades = this.SeedTrades(context);
            var characteristics = this.SeedCharacteristics(context);
            var products = this.SeedProducts(context, categories, trades);
            //var productCharacteristics = this.SeedProductCharacteristics(context, characteristics, categories, products);

        }

        private IList<Product> SeedProducts(ShopDbContext context, IList<Category> categories, IList<Trade> trades)
        {
            var products = new List<Product>();
            foreach (var category in categories)
            {
                for (int i = 0; i < 10; i++)
                {
                    var product = new Product()
                    {
                        Name = "Product " + category.Name + (i + 1),
                        Price = this.random.Next(100, 1001),
                        Quantity = 10,
                        Trade = trades[this.random.Next(0, trades.Count)],
                        Category = category,
                    };

                    context.Products.Add(product);
                    products.Add(product);

                }
            }

            context.SaveChanges();
            return products;
        }

        private IList<Characteristic> SeedProductCharacteristics(ShopDbContext context, IList<Characteristic> characteristics, IList<Category> categories, IList<Product> products)
        {
            throw new NotImplementedException();
        }

        private IList<Characteristic> SeedCharacteristics(ShopDbContext context)
        {
            var characteristics = new List<Characteristic>();
            var characteristicNames = new List<string>()
            {
                "Color",
                "Size",
                "CPU",
                "Memory",
                "Ram",
                "HDD",
                "Battery",
                "Other",
                "Display",

            };

            foreach (var name in characteristicNames)
            {
                var characteristic = new Characteristic()
                {
                    Name = name
                };

                context.Characteristics.Add(characteristic);
                characteristics.Add(characteristic);
            }

            context.SaveChanges();
            return characteristics;
        }

        private IList<Trade> SeedTrades(ShopDbContext context)
        {
            var trades = new List<Trade>();
            var tradesNames = new List<string>()
            {
                "Samsung",
                "LG",
                "Apple",
                "Lenovo",
                "Dell",
                "HP"
            };

            foreach (var name in tradesNames)
            {
                var trade = new Trade()
                {
                    Name = name
                };

                context.Trades.Add(trade);
                trades.Add(trade);
            }

            context.SaveChanges();
            return trades;
        }

        private IList<User> SeedUsers(ShopDbContext context)
        {
            var users = new List<User>();
            var userNames = new List<string>() { "admin", "maria", "andrei" };
            var manager = new UserManager<User>(new UserStore<User>(context));
            manager.PasswordValidator = new PasswordValidator()
            {
                RequireDigit = false,
                RequiredLength = 3,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false
            };

            foreach (var name in userNames)
            {
                var user = new User()
                {
                    UserName = name,
                    Email = name + "@gmail.com"
                };

                var password = name;

                var result = manager.Create(user, password);
                if (result.Succeeded)
                {
                    users.Add(user);
                }
                else
                {
                    throw new Exception(string.Join(",", result.Errors));
                }
            }


            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole("Administrator"));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }

            // Add "admin" user to "Administrator" role
            var adminUser = users.First(user => user.UserName == "admin");

            var addAdminRoleResult = manager.AddToRole(adminUser.Id, "Administrator");
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }

            context.SaveChanges();

            return users;
        }

        private IList<Category> SeedCategories(ShopDbContext context)
        {
            var categories = new List<Category>();
            var categoriesNames = new List<string>()
            {
                "Computers",
                "Laptops",
                "Tablets"               
            };

            foreach (var name in categoriesNames)
            {
                var category = new Category()
                {
                    Name = name
                };

                context.Categories.Add(category);
                categories.Add(category);
            }

            context.SaveChanges();
            return categories;
        }
    }
}
