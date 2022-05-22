using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly RestaurantDbContext context;

        public OrderDetailRepository(RestaurantDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(OrderDetail entity)
        {
            await context.OrderDetails.AddAsync(entity);
        }

        public async Task DeleteAsync(OrderDetail entity)
        {
            await Task.Run(() => context.OrderDetails.Remove(entity));
        }

        public async Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            return await context.OrderDetails.ToArrayAsync();
        }

        public async Task<IEnumerable<OrderDetail>> GetAllWithDetailsAsync()
        {
            return await context.OrderDetails
                .Include(od => od.Product)
                .ThenInclude(p => p.Category)
                .ToArrayAsync();
        }

        public async Task<OrderDetail> GetByIdAsync(int id)
        {
            return await context.OrderDetails.FirstOrDefaultAsync(od => od.Id == id);
        }

        public async Task<OrderDetail> GetByIdWithDetailsAsync(int id)
        {
            return await context.OrderDetails
                .Include(od => od.Product)
                .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync(od => od.Id == id);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderDetail entity)
        {
            await Task.Run(() => context.OrderDetails.Update(entity));
        }
    }
}
