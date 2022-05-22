using NUnit.Framework;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Test.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Test
{
    [TestFixture]
    internal class OrderRepositoryTest
    {
        private RestaurantDbContext context;

        private OrderRepository orderRepository;

        [SetUp]
        public void Setup()
        {
            context = new RestaurantDbContext(UnitTestHelper.GetUnitTestDbOptions());
           // context = new RestaurantDbContext();
            orderRepository = new OrderRepository(context);
        }

        [Test]
        public async Task OrderRepository_GetAllAsync_ReturnsValues()
        {
            //Arrange
            int expectedCount = 4;

            //Act
            var orders = await orderRepository.GetAllAsync();
            int actualCount = orders.Count();

            //Assert
            Assert.That(actualCount , Is.EqualTo(expectedCount) , "GetAllAsync method works incorrect");
        }


        [Test]
        public async Task OrderRepository_GetAllWithDetailsAsync_ReturnsValuesWithDetails()
        {
            //Arrange
            int expectedCount = 4;

            //Act
            var orders = await orderRepository.GetAllWithDetailsAsync();
            int actualCount = orders.Count();
            var order = orders.First();
            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "GetAllWithDetailsAsync method works incorrect");
            Assert.That(order.OrderDetails.Count, Is.Not.EqualTo(0), "GetAllWithDetailsAsync does not return order details");
            Assert.That(order.User, Is.Not.Null, "GetAllWithDetailsAsync does not return user");

        }

        [Test]
        public async Task OrderRepository_GetByIdAsync_ReturnsValue()
        {
            //Arrange
            var expected = new Order { Id = 1, UserId = 1, TotalSum = 100, IsComplete = true, Date = new DateTime(2020, 11, 10) };

            //Act
            var actual = await orderRepository.GetByIdAsync(expected.Id);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new OrderComparer()), "GetByIdAsync method works incorrect");
        }

        [Test]
        public async Task OrderRepository_GetByIdWithDetailsAsync_ReturnsValueWithDetails()
        {
            //Arrange
            var expected = new Order { Id = 1, UserId = 1, TotalSum = 100, IsComplete = true, Date = new DateTime(2020, 11, 10) };

            //Act
            var actual = await orderRepository.GetByIdWithDetailsAsync(expected.Id);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new OrderComparer()), "GetByIdWithDetailsAsync method works incorrect");
            Assert.That(actual.OrderDetails.Count, Is.Not.EqualTo(0), "GetByIdWithDetailsAsync does not return order details");
            Assert.That(actual.User, Is.Not.Null, "GetByIdWithDetailsAsync does not return user");
        }

        [Test]
        public async Task Order_Repository_AddAsync_AddsObjectToDatabase()
        {
            //Arrange
            var order = new Order { UserId = 1, TotalSum = 213, IsComplete = true, Date = new DateTime(2010, 11, 10) };
            int expectedCount = 5;

            //Act
            await orderRepository.AddAsync(order);
            await context.SaveChangesAsync();
            int actualCount = context.Orders.Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "AddAsync method works incorrect");
        }

        [Test]
        public async Task OrderRepository_UpdateAsync_UpdatesObjectFromDatabase()
        {
            //Arrange
            var expected = new Order { UserId = 1, TotalSum = 213, IsComplete = true, Date = new DateTime(2010, 11, 10) };

            //Act
            await orderRepository.UpdateAsync(expected);
            await context.SaveChangesAsync();

            var actual = context.Orders.FirstOrDefault(r => r.Id == expected.Id);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new OrderComparer()), "UpdateAsync method works incorrect");
        }

        [Test]
        public async Task OrderRepository_DeleteAsync_RemovesObjectFromDatabase()
        {
            //Arrange
            var order = new Order { Id = 1 };
            int expectedCount = 3;

            //Act
            await orderRepository.DeleteAsync(order);
            await context.SaveChangesAsync();
            int actualCount = context.Orders.Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "DeleteAsync method works incorrect");
        }
    }
}
