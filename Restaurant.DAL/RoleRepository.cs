using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RestaurantDbContext context;

        public RoleRepository(RestaurantDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Role entity)
        {
            await context.Roles.AddAsync(entity);
        }

        public async Task DeleteAsync(Role entity)
        {
            await Task.Run(() => context.Roles.Remove(entity));
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await context.Roles.ToArrayAsync();
        }

        public async Task<IEnumerable<Role>> GetAllWithDetailsAsync()
        {
            return await context.Roles.Include(r => r.Users).ToArrayAsync();
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await context.Roles.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Role> GetByIdWithDetailsAsync(int id)
        {
            return await context.Roles.Include(r => r.Users).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role entity)
        {
            await Task.Run(() => context.Roles.Update(entity));
        }
    }
}
