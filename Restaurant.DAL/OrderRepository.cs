using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantDbContext context;

        public OrderRepository(RestaurantDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Order entity)
        {
            await context.Orders.AddAsync(entity);
        }

        public async Task DeleteAsync(Order entity)
        {
            await Task.Run(() => context.Orders.Remove(entity));
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await context.Orders.ToArrayAsync();
        }

        public async Task<IEnumerable<Order>> GetAllWithDetailsAsync()
        {
            return await context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .ToArrayAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Order> GetByIdWithDetailsAsync(int id)
        {
            return await context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order entity)
        {
            await Task.Run(() => context.Orders.Update(entity));
        }
    }
}
