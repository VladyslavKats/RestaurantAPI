using Restaurant.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();

        Task<IEnumerable<OrderDto>> GetAllOrdersWithDetailsAsync();

        Task<OrderDto> AddOrderAsync(OrderDto order);

        Task UpdateOrderAsync(OrderDto order);

        Task DeleteOrderAsync(int id);

        Task<IEnumerable<OrderDto>> GetOrdersByUser(string login);

        Task CompleteOrderAsync(int orderId);
    }
}
