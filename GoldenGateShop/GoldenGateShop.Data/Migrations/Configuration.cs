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
            var characteristicTypes = this.SeedCharacteristicsTypes(context, categories);
            var products = this.SeedProducts(context, categories, trades, characteristicTypes);
            //var productCharacteristics = this.SeedProductCharacteristics(context, characteristics, categories, products);

        }

        private IList<Product> SeedProducts(ShopDbContext context, IList<Category> categories, IList<Trade> trades, IList<CharacteristicType> characteristicTypes)
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

                    foreach (var characteristic in category.CharacteristicTypes)
                    {
                        product.ProductCharacteristics.Add(new ProductCharacteristic()
                        {
                            CharacteristicTypeId = characteristic.Id,
                            CharacteristicValueId = characteristic.CharacteristicValue.ToList()[this.random.Next(0, characteristic.CharacteristicValue.Count())].Id,
                        });
                    }

                    context.Products.Add(product);
                    products.Add(product);

                }
            }

            context.SaveChanges();
            return products;
        }

        private IList<CharacteristicType> SeedProductCharacteristics(ShopDbContext context, IList<CharacteristicType> characteristics, IList<Category> categories, IList<Product> products)
        {
            throw new NotImplementedException();
        }

        private IList<CharacteristicType> SeedCharacteristicsTypes(ShopDbContext context, IList<Category> categories)
        {
            var characteristics = new List<CharacteristicType>();

            var i = 0;
            var charcter = new CharacteristicType()
            {
                Name = "Short Description",
                Position = ++i,
                Category = categories,
                CharacteristicValue = new HashSet<CharacteristicValue>()
                {
                    new CharacteristicValue()
                    {
                        Description = "Best computer for the price!",                        
                    },
                     new CharacteristicValue()
                    {
                        Description = "Enter in the world of games!",                        
                    },
                     new CharacteristicValue()
                    {
                        Description = "All the benefits of a desktop PC in an elegant, portable package.",                        
                    },
                     new CharacteristicValue()
                    {
                        Description = "The perfect solution for any office, at a reasonable price and with great performance for their goals. If you are looking for a budget solution for home or office Internet safirane and watching movies, it would be a great solution and a reasonable purchase!",                        
                    },
                     new CharacteristicValue()
                    {
                        Description = "The ideal laptop for work in the office and at home. Now with 36 months warranty!",                        
                    }

                },

            };

            context.Characteristics.Add(charcter);
            characteristics.Add(charcter);

            charcter = new CharacteristicType()
            {
                Name = "CPU",
                Position = ++i,
                Category = categories,
                CharacteristicValue = new HashSet<CharacteristicValue>()
                {
                    new CharacteristicValue()
                    {
                        Value = 2.70,
                        Description = "Intel® Core™ i5-4210U Processor (3M Cache, up to 2.70 GHz)",                        
                    },
                     new CharacteristicValue()
                    {
                        Value = 2.58,
                        Description = "Intel® Celeron® Processor N2840 (1M Cache, up to 2.58 GHz)",                        
                    },
                     new CharacteristicValue()
                    {
                        Value = 2.58,
                        Description = "Intel® Celeron® Processor N2840 (1M Cache, up to 2.58 GHz)",
                    },
                     new CharacteristicValue()
                    {
                        Value = 1.2,
                        Description = "Intel® Celeron® Processor N2840 (1M Cache, up to 1.2 GHz)",
                    },
                     new CharacteristicValue()
                    {
                        Value = 3.4,
                        Description = "Intel® Celeron® Processor N2840 (1M Cache, up to 3.4 GHz)",
                    }

                },

            };

            context.Characteristics.Add(charcter);
            characteristics.Add(charcter);

            charcter = new CharacteristicType()
            {
                Name = "HDD",
                Position = ++i,
                Category = categories,
                CharacteristicValue = new HashSet<CharacteristicValue>()
                {
                    new CharacteristicValue()
                    {
                        Value = 500,
                        Description = "500 GB",
                    },
                     new CharacteristicValue()
                    {
                         Value = 1024,
                        Description = "1 TB",
                    },
                     new CharacteristicValue()
                    {
                        Value = 2048,
                        Description = "2 TB",
                    }                    
                },

            };

            context.Characteristics.Add(charcter);
            characteristics.Add(charcter);

            charcter = new CharacteristicType()
            {
                Name = "Video processor",
                Position = ++i,
                Category = categories,
                CharacteristicValue = new HashSet<CharacteristicValue>()
                {
                    new CharacteristicValue()
                    {
                        Value = 1024,
                        Description = "NVIDIA® GeForce® GT620 1 GB",
                    },
                     new CharacteristicValue()
                    {
                         Value = 2048,
                        Description = "nVidia GeForce GTX750 2048MB",
                    },
                     new CharacteristicValue()
                    {
                        Value = 2048,
                        Description = "nVIDIA GeForce GT730 2048MB",
                    },
                      new CharacteristicValue()
                    {
                        Value = 1024,
                        Description = "NVIDIA GeForce GT 705 1024MB DDR3",
                    },
                      new CharacteristicValue()
                    {
                        Value = 1024,
                        Description = "Intel® HD Graphics",
                    }              
                },

            };

            context.Characteristics.Add(charcter);
            characteristics.Add(charcter);

            charcter = new CharacteristicType()
            {
                Name = "Ram",
                Position = ++i,
                Category = categories,
                CharacteristicValue = new HashSet<CharacteristicValue>()
                {
                     new CharacteristicValue()
                    {
                        Value = 4096,
                        Description = "4096 MB",
                    },
                     new CharacteristicValue()
                    {
                         Value = 1024,
                        Description = "1024 MB",
                    },
                     new CharacteristicValue()
                    {
                        Value = 2048,
                        Description = "2048 MB",
                    }                  
                },

            };

            context.Characteristics.Add(charcter);
            characteristics.Add(charcter);


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

            var i = 0;

            foreach (var name in categoriesNames)
            {
                var category = new Category()
                {
                    Name = name,
                    Position = ++i
                };

                context.Categories.Add(category);
                categories.Add(category);
            }


            context.SaveChanges();
            return categories;
        }
    }
}
