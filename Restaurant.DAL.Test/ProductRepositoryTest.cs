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
    internal class ProductRepositoryTest
    {
        private ProductRepository productRepository;

        private RestaurantDbContext context;

        [SetUp]
        public void Setup()
        {
            context = new RestaurantDbContext(UnitTestHelper.GetUnitTestDbOptions());
            //context = new RestaurantDbContext();
            productRepository = new ProductRepository(context);
        }

        [Test]
        public async Task ProductRepository_GetAllAsync_ReturnsValues()
        {
            //Arrange
            int expectedCount = 4;

            //Act
            var products = await productRepository.GetAllAsync();
            int actualCount = products.Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "GetAllAsync method works incorrect");
        }

        [Test]
        public async Task ProductRepository_GetAllWithDetailsAsync_ReturnsValuesWithDetails()
        {
            //Arrange
            int expectedCount = 4;

            //Act
            var products = await productRepository.GetAllWithDetailsAsync();
            int actualCount = products.Count();
            var product = products.First();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "GetAllWithDetailsAsync method works incorrect");
            Assert.That(product.Ingredients.Count, Is.Not.EqualTo(0), "GetAllWithDetailsAsync does not return ingredients");
            Assert.That(product.Category, Is.Not.Null, "GetAllWithDetailsAsync does not return category");
        }

        [Test]
        public async Task ProductRepository_GetByIdAsync_ReturnsValue()
        {
            //Arrange
            var expected = new Product { Id = 2, Name = "ProductName2", CategoryId = 1, Cost = 200, Weight = 500 };

            //Act
            var actual = await productRepository.GetByIdAsync(expected.Id);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new ProductComparer()), "GetByIdAsync method works incorrect");
        }

        [Test]
        public async Task ProductRepository_GetByIdWithDetailsAsync_ReturnsValueWithDetails()
        {
            //Arrange
            var expected = new Product { Id = 2, Name = "ProductName2", CategoryId = 1, Cost = 200, Weight = 500 };

            //Act
            var actual = await productRepository.GetByIdWithDetailsAsync(expected.Id);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new ProductComparer()), "GetByIdWithDetailsAsync method works incorrect");
            Assert.That(actual.Ingredients.Count, Is.Not.EqualTo(0), "GetByIdWithDetailsAsync does not return ingredients");
            Assert.That(actual.Category, Is.Not.Null, "GetByIdWithDetailsAsync does not return category");
        }

        [Test]
        public async Task ProductRepository_AddAsync_AddsObjectToDatabase()
        {
            //Arrange
            var product = new Product { Name = "productName", Weight = 200, CategoryId = 1, Cost = 120 };
            int expectedCount = 5;

            //Act
            await productRepository.AddAsync(product);
            await context.SaveChangesAsync();
            int actualCount = context.Products.Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "AddAsync method works incorrect");
        }


        [Test]
        public async Task ProductRepository_UpdateAsync_UpdatesObjectFromDatabase()
        {
            //Arrange
            var expected = new Product { Id = 1, Name = "ProductName1Updated", CategoryId = 2, Cost = 200, Weight = 500 };

            //Act
            await productRepository.UpdateAsync(expected);
            await context.SaveChangesAsync();

            var actual = context.Products.FirstOrDefault(r => r.Id == expected.Id);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new ProductComparer()), "UpdateAsync method works incorrect");
        }

        [Test]
        public async Task ProductRepository_DeleteAsync_RemovesObjectFromDatabase()
        {
            //Arrange
            var product = new Product { Id = 1 };
            int expectedCount = 3;

            //Act
            await productRepository.DeleteAsync(product);
            await context.SaveChangesAsync();
            int actualCount = context.Products.Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "DeleteAsync method works incorrect");
        }
    }
}
