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
    internal class RoleRepositoryTest
    {

        private RestaurantDbContext context;

        private RoleRepository roleRepository; 

        [SetUp]
        public void Setup()
        {
             context = new RestaurantDbContext(UnitTestHelper.GetUnitTestDbOptions());
            
            roleRepository = new RoleRepository(context);
        }


        [Test]
        public async Task RoleRepository_GetAllAsync_ReturnsValues()
        {
            //Arrange
            int expectedCount = 2;

            //Act
            var roles =  await roleRepository.GetAllAsync();
            int actualCount = roles.Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "GetAllAsync method works incorrect");
        }

        [Test]
        public async Task RoleRepository_GetByIdAsync_ReturnsValue()
        {
            //Arrange
            var expected = new Role { Id = 1, Name = "RoleName1" };

            //Act
            var actual = await roleRepository.GetByIdAsync(expected.Id);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new RoleComparer()), "GetByIdAsync method works incorrect");
        }


        [Test]
        public async Task RoleRepository_GetByIdWithDetailsAsync_ReturnsValueWithDetails()
        {
            //Arrange
            var expected = new Role { Id = 1, Name = "RoleName1" };
            int expectedUsersCount = 1;
            //Act
            var actual = await roleRepository.GetByIdWithDetailsAsync(expected.Id);
            var actualUsersCount = actual.Users.Count;
            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new RoleComparer()), "GetByIdAsync method works incorrect");
            Assert.That(actualUsersCount, Is.EqualTo(expectedUsersCount), "GetByIdAsync method does not return users");
        }

        [Test]
        public async Task RoleRepository_GetAllWithDetailsAsync_ReturnsValuesWithDetails()
        {
            //Arrange
            int expectedCount = 2;

            //Act
            var roles = await roleRepository.GetAllWithDetailsAsync();
            int actualCount = roles.Count();
            var role = roles.First();
            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "GetAllWithDetailsAsync method works incorrect");
            Assert.That(role.Users.Count, Is.Not.EqualTo(0), "GetAllWithDetailsAsync method does not return users");
        }


        [Test]
        public async Task RoleRepository_AddAsync_AddsObjectToDatabase()
        {
            //Arrange
            var role = new Role { Name = "RoleName3" };
            int expectedCount = 3;

            //Act
            await roleRepository.AddAsync(role);
            await context.SaveChangesAsync();
            int actualCount = context.Roles.Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "AddAsync method works incorrect");

        }


        [Test]
        public async Task RoleRepository_DeleteAsync_RemoveObjectFromDatabase()
        {
            //Arrange
            var role = new Role { Id = 1 };
            int expectedCount = 1;

            //Act
            await roleRepository.DeleteAsync(role);
            await context.SaveChangesAsync();
            int actualCount = context.Roles.Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "DeleteAsync method works incorrect");
        }

        [Test]
        public async Task RoleRepository_UpdateAsync_UpdatesValueFromDatabase()
        {
            //Arrange
            var expected = new Role { Id = 1, Name = "NameRole1Updated" };

            //Act
            await roleRepository.UpdateAsync(expected);
            await context.SaveChangesAsync();

            var actual = context.Roles.FirstOrDefault(r => r.Id == expected.Id);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new RoleComparer()), "UpdateAsync method works incorrect");
        }
    }
}
