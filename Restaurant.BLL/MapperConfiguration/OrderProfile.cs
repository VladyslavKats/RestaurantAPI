using AutoMapper;
using Restaurant.BLL.DTOs;
using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BLL.MapperConfiguration
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            this.CreateMap<Order, OrderDTO>();
            this.CreateMap<OrderDTO, Order>();
        }
    }
}
