using AutoMapper;
using Restaurant.BLL.DTOs;
using Restaurant.BLL.Interfaces;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
        public void Create(OrderDTO entity)
        {
            var item = mapper.Map<OrderDTO, Order>(entity);
            context.Orders.Add(item);
        }

        public void Delete(int id)
        {
            context.Orders.Delete(id);
        }

        public OrderDTO Get(int id)
        {
            var item = context.Orders.GetById(id);
            return mapper.Map<Order ,OrderDTO>(item);
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            var items = context.Orders.GetAll();
            return mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(items);
        }

        public void Save()
        {
            context.Save();
        }

        public void Update(OrderDTO entity)
        {
            var item = mapper.Map<OrderDTO , Order>(entity);
            context.Orders.Update(item);
        }
    }
}
