using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly RestaurantDbContext context;

        public UserRepository(RestaurantDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(User entity)
        {
            await context.Users.AddAsync(entity);
        }

        public async Task DeleteAsync(User entity)
        {
            await Task.Run(() => context.Users.Remove(entity));
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await context.Users
                .Include(u => u.Role)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<User>> GetAllWithDetailsAsync()
        {
            return await context.Users
                .Include(u => u.Role)
                .Include(u => u.Orders)
                .ThenInclude(o => o.OrderDetails)
                .ToArrayAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetByIdWithDetailsAsync(int id)
        {
            return await context.Users
                .Include(u => u.Role)
                .Include(u => u.Orders)
                .ThenInclude(o => o.OrderDetails)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();   
        }

        public async Task UpdateAsync(User entity)
        {
            await Task.Run(() => context.Users.Update(entity));
        }
    }
}
