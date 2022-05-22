using BCrypt.Net;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Restaurant.BLL.Interfaces;
using Restaurant.BLL.Models;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Restaurant.BLL.Services
{
    public class UserManager : IUserManager
    {
        private readonly IRestaurantUW context;
        private readonly IOptions<AuthOptions> options;

        public UserManager(IRestaurantUW context , IOptions<AuthOptions> options)
        {
            this.context = context;
            this.options = options;
        }

        /// <summary>
        /// Returns access token if model is valid , 
        /// if user does not exist return null
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Returns access token</returns>
        /// <exception cref="RestaurantException">Throw exception if model is invalid</exception>
        public async Task<AuthenticateResponse> LogIn(LogInModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Login) || string.IsNullOrEmpty(model.Password))
                throw new RestaurantException("incorrect data");
            var user = await getUserByLoginAsync(model.Login);
            if (user != null && BCrypt.Net.BCrypt.Verify(model.Password , user.Password))
            {
                string token = getToken(user);
                return new AuthenticateResponse { Token = token , Id = user.Id , Login = user.Login, PhoneNumber = user.PhoneNumber };
            }
               
            return null;
        }

        public async Task DeleteUserAsync(User user)
        {
            var users = await context.Users.GetAllAsync();
            var userFromDb = users.FirstOrDefault(u => u.Login == user.Login);
            if (userFromDb != null)
            {
                await context.Users.DeleteAsync(userFromDb);
                await context.SaveAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await context.Users.GetAllAsync();
            return users;
        }

        public async Task<User> getUserByLoginAsync(string login)
        {
            if (string.IsNullOrEmpty(login))
                throw new RestaurantException("incorrect data");
            var users = await context.Users.GetAllWithDetailsAsync();
            return users.FirstOrDefault(u => u.Login == login);
        }

        public async Task<AuthenticateResponse> Register(User user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Login) 
                || string.IsNullOrWhiteSpace(user.Password))
            {
                throw new RestaurantException("incorrect data");
            }
            user.Password = hashPassword(user.Password);
            var role = new Role { Id = 2, Name = "User" };
            user.RoleId = role.Id;
            await context.Users.AddAsync(user);
            await context.SaveAsync();
            user.Role = role;
            string token = getToken(user);
            return new AuthenticateResponse { Token = token , Id = user.Id , Login = user.Login , PhoneNumber = user.PhoneNumber};
        }

        private string getToken(User user)
        {
            var authParams = options.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();

            var credentials = new SigningCredentials(securityKey , SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>() {
                new Claim(JwtRegisteredClaimNames.Email , user.Login),
                new Claim("role" , user.Role.Name)
            };

            var token = new JwtSecurityToken(
                    authParams.Issuer ,
                    authParams.Audience,
                    claims,
                    expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task UpdateUserAsync(User user)
        {
            var users = await context.Users.GetAllAsync();
           
            var userFromDb = users.FirstOrDefault(u => u.Login == user.Login);
            if (userFromDb != null)
            {
                userFromDb.Password = hashPassword(user.Password);
                userFromDb.PhoneNumber = user.PhoneNumber;
                await context.Users.UpdateAsync(userFromDb);
                await context.SaveAsync();
            }
        }

        private string hashPassword(string password)
        {
           
            
            string hashed = BCrypt.Net.BCrypt.HashPassword(password, 12);
           
            return hashed;

        }

        public async Task<bool> CheckForLoginAsync(string login)
        {
            var user = await getUserByLoginAsync(login);
            return user == null;
        }
    }
}
