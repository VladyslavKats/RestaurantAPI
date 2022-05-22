using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Test.Comparers;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.DAL.Test
{
    public class CategoryRepositoryTest
    {

        private RestaurantDbContext context;

        private CategoryRepository categoryRepository;
        [SetUp]
        public void Setup()
        {
            context = new RestaurantDbContext(UnitTestHelper.GetUnitTestDbOptions());
            categoryRepository = new CategoryRepository(context);

           
        }

        [Test]
        public async Task CategoryRepository_GetAllAsync_ReturnsAllValues()
        {
            //Arrange
            var expected = new Category[] {
                new Category {Id = 1 , Name = "CategoryName1" } ,
                new Category {Id = 2 , Name = "CategoryName2" }
            };

            //Act
            var actual = await categoryRepository.GetAllAsync();

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new CategoryComparer()), "GetAllAsync method works incorrect");
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public async Task CategoryRepository_GetByIdAsync_ReturnsValue(int id)
        {
            //Arrange
            var expected = new Category { Id = id, Name = $"CategoryName{id}" };

            //Act
            var actual = await categoryRepository.GetByIdAsync(id);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new CategoryComparer()), "GetByIdAsync method works incorrect");
        }


        [Test]
        public async Task CategoryRepository_GetByIdWithDetailsAsync_ReturnsValueWithDetail()
        {
            //Arrange
            var expected = new Category { Id = 1, Name = $"CategoryName1" };

            //Act
            var actual = await categoryRepository.GetByIdWithDetailsAsync(expected.Id);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new CategoryComparer()), "GetByIdAsync method works incorrect");
            Assert.That(actual.Products.Count, Is.EqualTo(2).Using(new CategoryComparer()), "Products count is incorrect");
           
        }

        [Test]
        public async Task CategoryRepository_GetAllWithDetailsAsync_ReturnsAllValuesWithDetails()
        {
            //Arrange
            var expected = new Category[] {
                new Category { Id = 1,Name = "CategoryName1"},
                new Category { Id = 2,Name = "CategoryName2"}
            };

            //Act
            var actual = await categoryRepository.GetAllWithDetailsAsync();
            var actualCategory = actual.First();

            //Asssert
            Assert.That(actual, Is.EqualTo(expected).Using(new CategoryComparer()), "GetAllWithDetailsAsync method works incorrect");
            Assert.That(actual.Count, Is.EqualTo(expected.Length), "GetAllWithDetailsAsync method does not return all values");
            Assert.That(actualCategory.Products.Count, Is.Not.EqualTo(0), "GetAllWithDetailsAsync method does not include details");
        }

        [Test]
        public async Task CategoryRepository_AddAsync_AddsValueToDatabase()
        {
            //Arrange
            var category = new Category { Id = 3, Name = "CategoryName1" };
            int expectedCount = 3;

            //Act
            await categoryRepository.AddAsync(category);
            await context.SaveChangesAsync();
            int actualCount = context.Categories.Count();
            //
            Assert.That(actualCount, Is.EqualTo(expectedCount), "AddAsync method works incorrect");
        }

        [Test]
        public async Task CategoryRepository_DeleteAsync_RemovesObjectFromDatabase()
        {
            //Arrange
            var category = new Category { Id = 1 };
            int expectedCount = 1;

            //Act
            await categoryRepository.DeleteAsync(category);
            await context.SaveChangesAsync();

            int actualCount = context.Categories.Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "DeleteAsync works incorrect");

        }


        [Test]
        public async Task CategoryRepository_UpdateAsync_UpdatesObjectFromDb()
        {
            //Arrange
            var expected = new Category { Id = 1, Name = "CategoryName1Updated" };

            //Act
            await categoryRepository.UpdateAsync(expected);
            await context.SaveChangesAsync();

            var actual = await  context.Categories.FirstOrDefaultAsync(c => c.Id == expected.Id);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new CategoryComparer()), "UpdateAsync works incorrect");
        }

    }
}