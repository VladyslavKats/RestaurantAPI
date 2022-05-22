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
    internal class IngredientRepositoryTest
    {

        private RestaurantDbContext context;

        private IngredientRepository ingredientRepository;


        [SetUp]
        public void Setup()
        {
            context = new RestaurantDbContext(UnitTestHelper.GetUnitTestDbOptions());
            //context = new RestaurantDbContext();
            ingredientRepository = new IngredientRepository(context);
        }

        [Test]
        public async Task IngredientRepository_GetAllAsync_ReturnsValues()
        {
            //Arrange
            int expectedCount = 2;

           

            //Act
            var ingredients = await ingredientRepository.GetAllAsync();
            int actualCount = ingredients.Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "GetAllAsync method works incorrect");

        }


        [Test]
        public async Task IngredientRepository_GetAllWithDetailsAsync_ReturnsValuesWithDetails()
        {
            //Arrange
            int expectedCount = 2;

            //Act
            var ingredients = await ingredientRepository.GetAllWithDetailsAsync();
            int actualCount = ingredients.Count();
            var ingredient = ingredients.First();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "GetAllWithDetailsAsync method works incorrect");
            Assert.That(ingredient.Products.Count, Is.Not.EqualTo(0), "GetAllWithDetailsAsync does not return products");
        }

        [Test]
        public async Task IngredientRepository_GetByIdAsync_ReturnsValue()
        {
            //Arrange
            var expected = new Ingredient { Id = 1  , Name = "Ingredient1"};

            //Act
            var actual = await ingredientRepository.GetByIdAsync(expected.Id);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new IngredientComparer()), "GetByIdAsync method works incorrect");
            
        }

        [Test]
        public async Task IngredientRepository_GetByIdWithDetailsAsync_ReturnsValueWithDetails()
        {
            //Arrange
            var expected = new Ingredient { Id = 1, Name = "Ingredient1" };

            //Act
            var actual = await ingredientRepository.GetByIdWithDetailsAsync(expected.Id);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new IngredientComparer()), "GetByIdWithDetailsAsync method works incorrect");
            Assert.That(actual.Products.Count, Is.Not.EqualTo(0), "GetByIdWithDetailsAsync does not return products");

        }


        [Test]
        public async Task IngredientRepository_UpdateAsync_UpdatesObjectFromDb()
        {
            //Arrange
            var expected = new Ingredient { Id = 1, Name = "Ingredient1Updated" };

            //Act
            await ingredientRepository.UpdateAsync(expected);
            await context.SaveChangesAsync();
            var actual = context.Ingredients.FirstOrDefault(i => i.Id == expected.Id);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new IngredientComparer()), "UpdateAsyncs method works incorrect");
        }

        [Test]
        public async Task IngredientRepository_AddAsync_AddsObjectToDatabase()
        {
            //Arrange
            var ingredient = new Ingredient { Name = "newIngredient" };
            int expectedCount = 3;

            //Act
            await ingredientRepository.AddAsync(ingredient);
            await context.SaveChangesAsync();
            int actualCount = context.Ingredients.Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "AddAsync method works incorrect");
        }

        [Test]
        public async Task IngredientRepository_DeleteAsync_RemovesObjectFromDb()
        {
            //Arrange
            var ingredient = new Ingredient { Id = 1 };
            int expectedCount = 1;

            //Act
            await ingredientRepository.DeleteAsync(ingredient);
            await context.SaveChangesAsync();
            int actualCount = context.Ingredients.Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "DeleteAsync method works incorrect");
        }
    }
}
