using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.EF;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.DAL.Data
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(RestaurantDbContext context) : base(context, context.Orders)
        {
        }
    }
}
