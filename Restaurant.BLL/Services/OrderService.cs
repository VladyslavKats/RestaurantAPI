using AutoMapper;
using Restaurant.BLL.Interfaces;
using Restaurant.BLL.Models;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRestaurantUW context;
        private readonly IMapper mapper;

        public OrderService(IRestaurantUW context , IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        private void validateOrder(OrderDto order)
        {
            if (order == null || order.TotalSum < 0 || order.UserId <= 0)
                throw new RestaurantException("incorrect data");
            
        }

        public async Task<OrderDto> AddOrderAsync(OrderDto order)
        {
            validateOrder(order);
            var item = mapper.Map<Order>(order);
            item.TotalSum = 0;
            foreach (var od in item.OrderDetails)
            {
                var product = await  context.Products.GetByIdAsync(od.ProductId);
                if (product != null)
                {
                    item.TotalSum += product.Cost * od.Quantity;
                }
            }
            item.Date = DateTime.UtcNow;
            await context.Orders.AddAsync(item);
            await context.SaveAsync();
            return mapper.Map<OrderDto>(item);
        }

        public async Task DeleteOrderAsync(int id)
        {
            if (id <= 0)
                throw new RestaurantException("id must be more than 0");
            await context.Orders.DeleteAsync(new Order { Id = id});
            await context.SaveAsync();
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await context.Orders.GetAllAsync();
            return mapper.Map<IEnumerable<OrderDto>>(orders );
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersWithDetailsAsync()
        {
            var orders = await context.Orders.GetAllWithDetailsAsync();
            return mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByUser(string login)
        {
            if (string.IsNullOrEmpty(login))
                throw new RestaurantException("incorrect data");
            var orders = await context.Orders.GetAllWithDetailsAsync();
            var ordersByUser = orders.Where(o => o.User.Login == login).Select(o => o);
            return mapper.Map<IEnumerable<OrderDto>>(ordersByUser);
        }

        public async Task UpdateOrderAsync(OrderDto order)
        {
            validateOrder(order);
            var item = mapper.Map<Order>(order);
            await context.Orders.UpdateAsync(item);
            await context.SaveAsync();
        }

        public async Task CompleteOrderAsync(int orderId)
        {
            if (orderId <= 0)
                throw new RestaurantException("id must be more than 0");
            var order = await context.Orders.GetByIdAsync(orderId);
            if (order != null)
                order.IsComplete = true;
            await context.SaveAsync();
        }
    }
}
