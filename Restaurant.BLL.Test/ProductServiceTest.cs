using Moq;
using NUnit.Framework;
using Restaurant.BLL.Models;
using Restaurant.BLL.Services;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;
using System.Threading.Tasks;

namespace Restaurant.BLL.Test
{
    [TestFixture]
    public class ProductServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ProductService_AddCategoryAsync_AddsObject()
        {
            //Arrange
            var mockUnitOfWork = new Mock<IRestaurantUW>();

            mockUnitOfWork.Setup(x => x.Categories.AddAsync(It.IsAny<Category>()));
            var productService = new ProductService(mockUnitOfWork.Object , UnitTestHelper.CreateMapperProfile());

            var category = new CategoryDto { Id = 1, Name =  "CategoryName1" };
            //Act
            await productService.AddCategoryAsync(category);

            //Assert
            mockUnitOfWork.Verify(x => x.Categories.AddAsync(It.Is<Category>(c => c.Id == category.Id && c.Name == category.Name)), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveAsync(), Times.Once);
        }

        [Test]
        public void ProductService_AddCategoryAsync_ThrowsRestaurantException()
        {
            //Arrange
            var mockUnitOfWork = new Mock<IRestaurantUW>();
            mockUnitOfWork.Setup(x => x.Categories.AddAsync(It.IsAny<Category>()));
            var productService = new ProductService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());
            var category = new CategoryDto { Id = 1, Name = "" };
            //Act
            AsyncTestDelegate action = async () => await productService.AddCategoryAsync(category);
            //Assert
            Assert.ThrowsAsync<RestaurantException>(action, "AddCategoryAsync method does not throw exception");
        }
    }
}