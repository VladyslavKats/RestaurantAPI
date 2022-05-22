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
    internal class OrderDetailRepositoryTest
    {
        private RestaurantDbContext context;

        private OrderDetailRepository orderDetailRepository;

        [SetUp]
        public void Setup()
        {
            context = new RestaurantDbContext(UnitTestHelper.GetUnitTestDbOptions());
            //context = new RestaurantDbContext();
            orderDetailRepository = new OrderDetailRepository(context);
        }

        [Test]
        public async Task OrderDetailRepository_GetAllAsync_ReturnsValues()
        {
            //Arrange
            int expectedCount = 4;

            //Act
            var orderDetails = await orderDetailRepository.GetAllAsync();
            int actualCount = orderDetails.Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "GetAllAsync method works incorrect");
        }


        [Test]
        public async Task OrderDetailRepository_GetAllWithDetailsAsync_ReturnsValuesWithDetails()
        {
            //Arrange
            int expectedCount = 4;

            //Act
            var orderDetails = await orderDetailRepository.GetAllWithDetailsAsync();
            int actualCount = orderDetails.Count();
            var orderDetail = orderDetails.First();
            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "GetAllWithDetailsAsync method works incorrect");
            Assert.That(orderDetail.Product ,  Is.Not.Null, "GetAllWithDetailsAsync does not return product");
            

        }

        [Test]
        public async Task OrderDetailRepository_GetByIdAsync_ReturnsValue()
        {
            //Arrange
            var expected = new OrderDetail { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1 };

            //Act
            var actual = await orderDetailRepository.GetByIdAsync(expected.Id);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new OrderDetailComparer()), "GetByIdAsync method works incorrect");
        }

        [Test]
        public async Task OrderDetailRepository_GetByIdWithDetailsAsync_ReturnsValueWithDetails()
        {
            //Arrange
            var expected = new OrderDetail { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1 };

            //Act
            var actual = await orderDetailRepository.GetByIdWithDetailsAsync(expected.Id);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new OrderDetailComparer()), "GetByIdAsync method works incorrect");
            Assert.That(actual.Product, Is.Not.Null, "GetAllWithDetailsAsync does not return product");
        }

        [Test]
        public async Task OrderDetailRepository_AddAsync_AddsObjectToDatabase()
        {
            //Arrange
            var orderDetail = new OrderDetail { OrderId = 1, ProductId = 1, Quantity = 3 };
            int expectedCount = 5;

            //Act
            await orderDetailRepository.AddAsync(orderDetail);
            await context.SaveChangesAsync();
            int actualCount = context.OrderDetails.Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "AddAsync method works incorrect");
        }

        [Test]
        public async Task OrderDetailRepository_UpdateAsync_UpdatesObjectFromDatabase()
        {
            //Arrange
            var expected = new OrderDetail { Id = 1, OrderId = 1, ProductId = 1, Quantity = 3 };

            //Act
            await orderDetailRepository.UpdateAsync(expected);
            await context.SaveChangesAsync();

            var actual = context.OrderDetails.FirstOrDefault(r => r.Id == expected.Id);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new OrderDetailComparer()), "UpdateAsync method works incorrect");
        }

        [Test]
        public async Task OrderDetailRepository_DeleteAsync_RemovesObjectFromDatabase()
        {
            //Arrange
            var orderDetail = new OrderDetail { Id = 1 };
            int expectedCount = 3;

            //Act
            await orderDetailRepository.DeleteAsync(orderDetail);
            await context.SaveChangesAsync();
            int actualCount = context.OrderDetails.Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "DeleteAsync method works incorrect");
        }
    }
}
