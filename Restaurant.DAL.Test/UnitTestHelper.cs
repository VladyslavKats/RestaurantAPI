using Microsoft.EntityFrameworkCore;
using System;
using Restaurant.DAL;
using Restaurant.DAL.Entities;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.DAL.Test
{
    internal static class UnitTestHelper
    {
        public static DbContextOptions<RestaurantDbContext> GetUnitTestDbOptions()
        {
            var options = new DbContextOptionsBuilder<RestaurantDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;


            using (var context = new RestaurantDbContext(options))
            {
                SeedData(context);
            }

            return options;
        }

        private static void SeedData(RestaurantDbContext context)
        {

            context.Roles.AddRange(
                new Role { Id = 1 , Name = "RoleName1"},
                new Role { Id = 2 , Name = "RoleName2"}
            );

            context.Users.AddRange(
                new User { Id = 1 , RoleId = 1 , Password = "password1" , Login = "login1" , PhoneNumber = "phoneNumber1"},
                new User { Id = 2 , RoleId = 2 , Password = "password2" , Login = "login2" , PhoneNumber = "phoneNumber2"}
            );


            context.Categories.AddRange(
                new Category {Id = 1 , Name = "CategoryName1" } ,
                new Category {Id = 2 , Name = "CategoryName2" }
            );

            var product1 = new Product { Id = 1, Name = "ProductName1", CategoryId = 1, Cost = 100, Weight = 400 };
            var product2 = new Product { Id = 2, Name = "ProductName2", CategoryId = 1, Cost = 200, Weight = 500 };
            var product3 = new Product { Id = 3, Name = "ProductName3", CategoryId = 2, Cost = 150, Weight = 450 };
            var product4 = new Product { Id = 4, Name = "ProductName4", CategoryId = 2, Cost = 300, Weight = 600 };

            var ingredient1 = new Ingredient { Id = 1, Name = "Ingredient1" };
            var ingredient2 = new Ingredient { Id = 2, Name = "Ingredient2" };

            product1.Ingredients.Add(ingredient1);
            product2.Ingredients.Add(ingredient2);
            product3.Ingredients.Add(ingredient2);
            product4.Ingredients.Add(ingredient1);


            context.Products.AddRange(
                product1,
                product2,
                product3,
                product4
            );

            context.Ingredients.AddRange(
                ingredient1,
                ingredient2
            );


           


            context.Orders.AddRange(
                new Order { Id = 1 , UserId = 1 , TotalSum = 100 , IsComplete = true , Date = new DateTime(2020 , 11 , 10)},
                new Order { Id = 2 , UserId = 1 , TotalSum = 200 , IsComplete = false , Date = new DateTime(2022 , 3 , 10)},
                new Order { Id = 3 , UserId = 2 , TotalSum = 300 , IsComplete = true , Date = new DateTime(2020 , 3 , 10)},
                new Order { Id = 4 , UserId = 2, TotalSum = 300 , IsComplete = false , Date = new DateTime(2021 , 3 , 10)}
            );

            context.OrderDetails.AddRange(
                new OrderDetail { Id = 1 , OrderId = 1,  ProductId = 1 , Quantity = 1 },
                new OrderDetail { Id = 2 , OrderId = 2,  ProductId = 2 , Quantity = 1 },
                new OrderDetail { Id = 3 , OrderId = 3,  ProductId = 3 , Quantity = 2 },
                new OrderDetail { Id = 4 , OrderId = 4,  ProductId = 4 , Quantity = 1 }
            );

            context.SaveChanges();
        }
    }
}
