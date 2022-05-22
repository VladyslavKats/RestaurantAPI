using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.DAL
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
            
            Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Orders).WithOne(u => u.User).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Products).OnDelete(DeleteBehavior.SetNull);        


            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Administrator" },
                new Role { Id = 2, Name = "User" }
            );

            modelBuilder.Entity<User>().HasData(
                //password : Admin123
                new User { Id = 1, RoleId = 1, Password = "$2a$12$ie9R50Trbh8G0AMkqmGi7eR8EpgKJXSrekpeUs3VwOPTASNotdsTe", Login = "admin@restaurant.com", PhoneNumber = "0677678634"},
                //password : VladKats123
                new User { Id = 2, RoleId = 2, Password = "$2a$12$QLyrnlYxql6mShPy/Y.4hODTslCkM008Kc3ZYOq4bmGxWX7.2FNuq", Login = "user@test.com", PhoneNumber = "0676512534" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Pizza" },
                new Category { Id = 2, Name = "Sushi" },
                new Category { Id = 3, Name = "WOK" }

            );

           
            //Pizza
            var product1 = new Product { Id = 1, Name = "Papperoni", CategoryId = 1, Cost = 205, Weight = 450 };
            var product2 = new Product { Id = 2, Name = "Diablo", CategoryId = 1, Cost = 215, Weight = 500 };
            var product3 = new Product { Id = 3, Name = "Four cheese", CategoryId = 1, Cost = 250, Weight = 450 };
            var product4 = new Product { Id = 4, Name = "Salyami", CategoryId = 1, Cost = 220, Weight = 550 };
            var product5 = new Product { Id = 5, Name = "Margarita", CategoryId = 1, Cost = 200, Weight = 500 };
            var product6 = new Product { Id = 6, Name = "Hawaiian", CategoryId = 1, Cost = 230, Weight = 450 };
            var product7 = new Product { Id = 7, Name = "Vegeterian", CategoryId = 1, Cost = 220, Weight = 490 };
            var product8 = new Product { Id = 8, Name = "Caesar", CategoryId = 1, Cost = 250, Weight = 530 };


            //Sushi
            
            var product9 = new Product { Id = 9, Name = "Tuna Tataki", CategoryId = 2, Cost = 130, Weight = 250 };
            var product10 = new Product { Id = 10, Name = "Mango roll", CategoryId = 2, Cost = 270, Weight = 215 };
            var product11 = new Product { Id = 11, Name = "California with salmon", CategoryId = 2, Cost = 260, Weight = 220 };
            var product12 = new Product { Id = 12, Name = "Tokio roll", CategoryId = 2, Cost = 140, Weight = 250 };
            var product13= new Product { Id = 13, Name = "Spider roll", CategoryId = 2, Cost = 155, Weight = 230 };
            var product14 = new Product { Id = 14, Name = "Kanada roll", CategoryId = 2, Cost = 230, Weight = 240 };
            var product15 = new Product { Id = 15, Name = "Cheese roll", CategoryId = 2, Cost = 105, Weight = 220 };


            //WOK
            var product16 = new Product { Id = 16, Name = "Rice with Chiken", CategoryId = 3, Cost = 120, Weight = 400 };
            var product17 = new Product { Id = 17, Name = "Udon with beacon", CategoryId = 3, Cost = 125, Weight = 400 };
            var product18 = new Product { Id = 18, Name = "Soba with vegetables", CategoryId = 3, Cost = 105, Weight = 400 };
            var product19 = new Product { Id = 19, Name = "Funchoza seafood", CategoryId = 3, Cost = 185, Weight = 400 };
            var product20 = new Product { Id = 20, Name = "Rice with shrimps", CategoryId = 3, Cost = 175, Weight = 400 };
            var product21 = new Product { Id = 21, Name = "Soba with turkey", CategoryId = 3, Cost = 145, Weight = 400 };
            var product22 = new Product { Id = 22, Name = "Rice with veal", CategoryId = 3, Cost = 125, Weight = 400 };


            //Ingredients


            //pizza 1
            var ingredient1 = new Ingredient { Id = 1, Name = "salyami" };
            var ingredient2 = new Ingredient { Id = 2, Name = "mozzarella" };
            var ingredient3 = new Ingredient { Id = 3, Name = "tomato sauce" };
            var ingredient4 = new Ingredient { Id = 4, Name = "champignons" };
            var ingredient5 = new Ingredient { Id = 5, Name = "oregano" };

            //piza 2
            var ingredient6 = new Ingredient { Id = 6, Name = "tabasco" };
            var ingredient7 = new Ingredient { Id = 7, Name = "italian sousages" };
            var ingredient8 = new Ingredient { Id = 8, Name = "onion" };
            var ingredient9 = new Ingredient { Id = 9, Name = "bavarian sausages" };

            //pizza 3
            var ingredient10 = new Ingredient { Id = 10, Name = "alfredo sause" };
            var ingredient11 = new Ingredient { Id = 11, Name = "dor blue" };
            var ingredient12 = new Ingredient { Id = 12, Name = "parmezan" };
            var ingredient13 = new Ingredient { Id = 13, Name = "cheddar" };

            //pizza 4
            var ingredient14 = new Ingredient { Id = 14, Name = "olives" };

            //pizza 5
            var ingredient15 = new Ingredient { Id = 15, Name = "tomatoes" };
            var ingredient16 = new Ingredient { Id = 16, Name = "basil" };
            var ingredient17 = new Ingredient { Id = 17, Name = "olive oil" };

            //pizza 6
            var ingredient18 = new Ingredient { Id = 18, Name = "chiken" };
            var ingredient19 = new Ingredient { Id = 19, Name = "pineapple" };
            var ingredient20 = new Ingredient { Id = 20, Name = "corn" };

            //pizza 7
            var ingredient21 = new Ingredient { Id = 21, Name = "Bualgaeian papper" };
            var ingredient22 = new Ingredient { Id = 22, Name = "black eyed peas" };

            //pizza 8
            var ingredient23 = new Ingredient { Id = 23, Name = "beacon" };
            var ingredient24 = new Ingredient { Id = 24, Name = "charries" };
            var ingredient25 = new Ingredient { Id = 25, Name = "salad iceberg" };
            var ingredient26 = new Ingredient { Id = 26, Name = "quail eggs" };


            //sushi 1
            var ingredient27 = new Ingredient { Id = 27, Name = "rice" };
            var ingredient28 = new Ingredient { Id = 28, Name = "nori" };
            var ingredient29 = new Ingredient { Id = 29, Name = "tuna" };
            var ingredient30 = new Ingredient { Id = 30, Name = "philadelphia cheese" };
            var ingredient31 = new Ingredient { Id = 31, Name = "cucumber" };
            var ingredient32 = new Ingredient { Id = 32, Name = "chili pepper" };


            //sushi 2
            var ingredient33 = new Ingredient { Id = 33, Name = "salmon" };
            var ingredient34 = new Ingredient { Id = 34, Name = "mango" };
            var ingredient35 = new Ingredient { Id = 35, Name = "tiger shrimp" };
            var ingredient36 = new Ingredient { Id = 36, Name = "microgeen" };

            //sushi 3
            var ingredient37 = new Ingredient { Id = 37, Name = "tobiko caviar" };
            var ingredient38 = new Ingredient { Id = 38, Name = "Japanese mayonnaise" };
            var ingredient39 = new Ingredient { Id = 39, Name = "avocado" };

            //sushi 4


            //sushi 5
            var ingredient40 = new Ingredient { Id = 40, Name = "scrambled eggs" };
            var ingredient41 = new Ingredient { Id = 41, Name = "snow crab" };
            var ingredient42 = new Ingredient { Id = 42, Name = "tobika" };

            //sushi 6
            var ingredient43 = new Ingredient { Id = 43, Name = "unagi sauce" };
            var ingredient44 = new Ingredient { Id = 44, Name = "eel" };






            //WOK 1
            var ingredient45 = new Ingredient { Id = 45, Name = "Chinese cabbage" };
            var ingredient46 = new Ingredient { Id = 46, Name = "carrot" };
            var ingredient47 = new Ingredient { Id = 47, Name = "sesame" };


            //WOK 2
            var ingredient48 = new Ingredient { Id = 48, Name = "udon" };
            var ingredient49 = new Ingredient { Id = 49, Name = "soy sauce" };

            //WOK 3
            var ingredient50 = new Ingredient { Id = 50, Name = "soba" };
            var ingredient51 = new Ingredient { Id = 51, Name = "brokolli" };

            //WOK 4
            var ingredient52 = new Ingredient { Id = 52, Name = "funchoza" };
            var ingredient53 = new Ingredient { Id = 53, Name = "mussels" };
            var ingredient54 = new Ingredient { Id = 54, Name = "shrimps" };
            var ingredient55 = new Ingredient { Id = 55, Name = "turkey" };
            var ingredient56 = new Ingredient { Id = 56, Name = "veal" };
            var ingredient57 = new Ingredient { Id = 57, Name = "peanut" };

          
            modelBuilder.Entity<Product>().HasData(
                product1,
                product2,
                product3,
                product4,
                product5,
                product6,
                product7,
                product8,
                product9,
                product10,
                product11,
                product12,
                product13,
                product14,
                product15,
                product16,
                product17,
                product18,
                product19,
                product20,
                product21,
                product22      
            );

            modelBuilder.Entity<Ingredient>().HasData(
              ingredient1 ,
              ingredient2,
              ingredient3,
              ingredient4,
              ingredient5,
              ingredient6,
              ingredient7,
              ingredient8,
              ingredient9,
              ingredient10,
              ingredient11,
              ingredient12,
              ingredient13,
              ingredient14,
              ingredient15,
              ingredient16,
              ingredient17,
              ingredient18,
              ingredient19,
              ingredient20,
              ingredient21,
              ingredient22,
              ingredient23,
              ingredient24,
              ingredient25,
              ingredient26,
              ingredient27,
              ingredient28,
              ingredient29,
              ingredient30,
              ingredient31,
              ingredient32,
              ingredient33,
              ingredient34,
              ingredient35,
              ingredient36,
              ingredient37,
              ingredient38,
              ingredient39,
              ingredient40,
              ingredient41,
              ingredient42,
              ingredient43,
              ingredient44,
              ingredient45,
              ingredient46,
              ingredient47,
              ingredient48,
              ingredient49,
              ingredient50,
              ingredient51,
              ingredient52,
              ingredient53,
              ingredient54,
              ingredient55,
              ingredient56,
              ingredient57
           );

            modelBuilder
                   .Entity<Product>()
                   .HasMany(p => p.Ingredients)
                   .WithMany(i => i.Products)
                   .UsingEntity(j => j.HasData(
                            new { IngredientsId = 1, ProductsId = 1 },
                            new { IngredientsId = 2, ProductsId = 1 },
                            new { IngredientsId = 3, ProductsId = 1 },
                            new { IngredientsId = 4, ProductsId = 1 },
                            new { IngredientsId = 5, ProductsId = 1 },
                            new { IngredientsId = 1, ProductsId = 2 },
                            new { IngredientsId = 2, ProductsId = 2 },
                            new { IngredientsId = 6, ProductsId = 2 },
                            new { IngredientsId = 7, ProductsId = 2 },
                            new { IngredientsId = 8, ProductsId = 2 },
                            new { IngredientsId = 9, ProductsId = 2 },
                            new { IngredientsId = 10, ProductsId = 3 },
                            new { IngredientsId = 11, ProductsId = 3 },
                            new { IngredientsId = 12, ProductsId = 3 },
                            new { IngredientsId = 13, ProductsId = 3 },
                            new { IngredientsId = 2, ProductsId = 3 },
                            new { IngredientsId = 3, ProductsId = 4 },
                            new { IngredientsId = 2, ProductsId = 4 },
                            new { IngredientsId = 1, ProductsId = 4 },
                            new { IngredientsId = 15, ProductsId = 5 },
                            new { IngredientsId = 16, ProductsId = 5 },
                            new { IngredientsId = 17, ProductsId = 5 },
                            new { IngredientsId = 3, ProductsId = 5 },
                            new { IngredientsId = 2, ProductsId = 5 },
                            new { IngredientsId = 18, ProductsId = 6 },
                            new { IngredientsId = 19, ProductsId = 6 },
                            new { IngredientsId = 20, ProductsId = 6 },
                            new { IngredientsId = 2, ProductsId = 6 },
                            new { IngredientsId = 21, ProductsId = 7 },
                            new { IngredientsId = 22, ProductsId = 7 },
                            new { IngredientsId = 17, ProductsId = 7 },
                            new { IngredientsId = 16, ProductsId = 7 },
                            new { IngredientsId = 4, ProductsId = 7 },
                            new { IngredientsId = 15, ProductsId = 7 },
                            new { IngredientsId = 3, ProductsId = 7 },
                            new { IngredientsId = 2, ProductsId = 7 },
                            new { IngredientsId = 20, ProductsId = 7 },
                            new { IngredientsId = 2, ProductsId = 8 },
                            new { IngredientsId = 18, ProductsId = 8 },
                            new { IngredientsId = 23, ProductsId = 8 },
                            new { IngredientsId = 12, ProductsId = 8 },
                            new { IngredientsId = 26, ProductsId = 8 },
                            new { IngredientsId = 24, ProductsId = 8 },
                            new { IngredientsId = 25, ProductsId = 8 },
                            new { IngredientsId = 27, ProductsId = 9 },
                            new { IngredientsId = 28, ProductsId = 9 },
                            new { IngredientsId = 29, ProductsId = 9 },
                            new { IngredientsId = 30, ProductsId = 9 },
                            new { IngredientsId = 31, ProductsId = 9 },
                            new { IngredientsId = 32, ProductsId = 9 },
                            new { IngredientsId = 27, ProductsId = 10 },
                            new { IngredientsId = 28, ProductsId = 10 },
                            new { IngredientsId = 33, ProductsId = 10 },
                            new { IngredientsId = 34, ProductsId = 10 },
                            new { IngredientsId = 35, ProductsId = 10 },
                            new { IngredientsId = 36, ProductsId = 10 },
                            new { IngredientsId = 27, ProductsId = 11 },
                            new { IngredientsId = 28, ProductsId = 11 },
                            new { IngredientsId = 37, ProductsId = 11 },
                            new { IngredientsId = 38, ProductsId = 11 },
                            new { IngredientsId = 39, ProductsId = 11 },
                            new { IngredientsId = 27, ProductsId = 12 },
                            new { IngredientsId = 28, ProductsId = 12 },
                            new { IngredientsId = 37, ProductsId = 12 },
                            new { IngredientsId = 33, ProductsId = 12 },
                            new { IngredientsId = 39, ProductsId = 12 },
                            new { IngredientsId = 31, ProductsId = 12 },
                            new { IngredientsId = 27, ProductsId = 13 },
                            new { IngredientsId = 28, ProductsId = 13 },
                            new { IngredientsId = 30, ProductsId = 13 },
                            new { IngredientsId = 40, ProductsId = 13 },
                            new { IngredientsId = 41, ProductsId = 13 },
                            new { IngredientsId = 42, ProductsId = 13 },
                            new { IngredientsId = 25, ProductsId = 13 },
                            new { IngredientsId = 27, ProductsId = 14 },
                            new { IngredientsId = 28, ProductsId = 14 },
                            new { IngredientsId = 39, ProductsId = 14 },
                            new { IngredientsId = 31, ProductsId = 14 },
                            new { IngredientsId = 33, ProductsId = 14 },
                            new { IngredientsId = 43, ProductsId = 14 },
                            new { IngredientsId = 44, ProductsId = 14 },
                            new { IngredientsId = 27, ProductsId = 15 },
                            new { IngredientsId = 30, ProductsId = 15 },
                            new { IngredientsId = 13, ProductsId = 15 },
                            new { IngredientsId = 27, ProductsId = 16 },
                            new { IngredientsId = 18, ProductsId = 16 },
                            new { IngredientsId = 45, ProductsId = 16 },
                            new { IngredientsId = 8, ProductsId = 16 },
                            new { IngredientsId = 21, ProductsId = 16 },
                            new { IngredientsId = 46, ProductsId = 16 },
                            new { IngredientsId = 47, ProductsId = 16 },
                            new { IngredientsId = 48, ProductsId = 17 },
                            new { IngredientsId = 49, ProductsId = 17 },
                            new { IngredientsId = 23, ProductsId = 17 },
                            new { IngredientsId = 18, ProductsId = 17 },
                            new { IngredientsId = 8, ProductsId = 17 },
                            new { IngredientsId = 46, ProductsId = 17 },
                            new { IngredientsId = 50, ProductsId = 18 },
                            new { IngredientsId = 51, ProductsId = 18 },
                            new { IngredientsId = 45, ProductsId = 18 },
                            new { IngredientsId = 4, ProductsId = 18 },
                            new { IngredientsId = 15, ProductsId = 18 },
                            new { IngredientsId = 8, ProductsId = 18 },
                            new { IngredientsId = 46, ProductsId = 18 },
                            new { IngredientsId = 52, ProductsId = 19 },
                            new { IngredientsId = 53, ProductsId = 19 },
                            new { IngredientsId = 54, ProductsId = 19 },
                            new { IngredientsId = 46, ProductsId = 19 },
                            new { IngredientsId = 8, ProductsId = 19 },
                            new { IngredientsId = 45, ProductsId = 19 },
                            new { IngredientsId = 21, ProductsId = 19 },
                            new { IngredientsId = 27, ProductsId = 20 },
                            new { IngredientsId = 54, ProductsId = 20 },
                            new { IngredientsId = 51, ProductsId = 20 },
                            new { IngredientsId = 46, ProductsId = 20 },
                            new { IngredientsId = 50, ProductsId = 21 },                       
                            new { IngredientsId = 55, ProductsId = 21 },
                            new { IngredientsId = 20, ProductsId = 21 },
                            new { IngredientsId = 19, ProductsId = 21 },
                            new { IngredientsId = 27, ProductsId = 22 },
                            new { IngredientsId = 56, ProductsId = 22 },
                            new { IngredientsId = 45, ProductsId = 22 },
                            new { IngredientsId = 4, ProductsId = 22 },
                            new { IngredientsId = 46, ProductsId = 22 },
                            new { IngredientsId = 57, ProductsId = 22 }
                    )) ;
                    
          
        }





        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        

    }
}
