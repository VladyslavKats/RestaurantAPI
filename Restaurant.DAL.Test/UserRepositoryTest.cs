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
    internal class UserRepositoryTest 
    {
        private UserRepository userRepository;

        private RestaurantDbContext context;

        [SetUp]
        public void Setup()
        {
           context = new RestaurantDbContext(UnitTestHelper.GetUnitTestDbOptions());
           // context = new RestaurantDbContext();
            userRepository = new UserRepository(context);
        }


        [Test]
        public async Task UserRepository_GetAllAsync_ReturnsValues()
        {
            //Arrange
            int expectedCount = 2;

            //Act
            var users = await userRepository.GetAllAsync();
            int actualCount = users.Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "GetAllAsync method works incorrect");
        }


        [Test]
        public async Task UserRepository_GetAllWithDetailsAsync_ReturnsValuesWithDetails()
        {
            //Arrange
            int expectedCount = 2;

            //Act
            var users = await userRepository.GetAllWithDetailsAsync();
            var user = users.First();
            int actualCount = users.Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "GetAllAsync method works incorrect");
            Assert.That(user.Role, Is.Not.Null, "GetAllAsync does not return role");
            Assert.That(user.Orders.Count, Is.Not.EqualTo(0), "GetAllAsync does not return orders");

        }

        [Test]
        public async Task UserRepository_GetByIdAsync_ReturnsValue()
        {
            //Arrange
            var expected = new User { Id = 1, RoleId = 1, Password = "password1", Login = "login1", PhoneNumber = "phoneNumber1" };

            //Act
            var actual = await userRepository.GetByIdAsync(expected.Id);

            //Assert
            Assert.That(actual , Is.EqualTo(expected).Using(new UserComparer()) , "GetByIdAsync method works incorrect");
        }


        [Test]
        public async Task UserRepository_GetByIdWithDetailsAsync_ReturnsValueWithDetails()
        {
            //Arrange
            var expected = new User { Id = 1, RoleId = 1, Password = "password1", Login = "login1", PhoneNumber = "phoneNumber1" };

            //Act
            var actual = await userRepository.GetByIdWithDetailsAsync(expected.Id);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new UserComparer()), "GetByIdWithDetailsAsync method works incorrect");
            Assert.That(actual.Role, Is.Not.Null, "GetByIdWithDetailsAsync does not return role");
            Assert.That(actual.Orders.Count, Is.Not.EqualTo(0), "GetByIdWithDetailsAsync does not return orders");
        }

        [Test]
        public async Task UserRepository_AddAsync_AddsObjectToDatabase()
        {
            //Arrange
            var user = new User { Login = "LoginUser3", Password = "PasswordUser3", PhoneNumber = "1231231", RoleId = 1 };
            int expectedCount = 3;

            //Act
            await userRepository.AddAsync(user);
            await context.SaveChangesAsync();
            int actualCount = context.Users.Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "AddAsync method works incorrect");
        }

        [Test]
        public async Task UserRepository_DeleteAsync_RemovesObjectFromDb()
        {
            //Arrange
            var user = new User {Id = 1 };
            int expectedCount = 1;

            //Act
            await userRepository.DeleteAsync(user);
            await context.SaveChangesAsync();
            int actualCount = context.Users.Count();

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "DeleteAsync method works incorrect");
        }

        [Test]
        public async Task UserRepository_UpdateAsync_UpdatesObjectFromDb()
        {
            //Arrange
            var expected = new User { Id = 1, RoleId = 2, Password = "password1Updated", Login = "login1Updated", PhoneNumber = "phoneNumber1Updated" };

            //Act
            await userRepository.UpdateAsync(expected);
            await context.SaveChangesAsync();
            var actual = context.Users.FirstOrDefault(u => u.Id == expected.Id);

            //Assert
            Assert.That(actual, Is.EqualTo(expected).Using(new UserComparer()), "UpdateAsync method works incorrect");
        }
    }
}
