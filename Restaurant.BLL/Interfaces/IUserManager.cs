using Restaurant.BLL.Models;
using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Interfaces
{
    public interface IUserManager
    {
        Task<bool> CheckForLoginAsync(string login);

        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<AuthenticateResponse> Register(User user);

        Task<AuthenticateResponse> LogIn(LogInModel model);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(User user);


    }
}
