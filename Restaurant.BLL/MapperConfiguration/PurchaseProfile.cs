using AutoMapper;
using Restaurant.BLL.DTOs;
using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BLL.MapperConfiguration
{
    public class PurchaseProfile : Profile
    {
        public PurchaseProfile()
        {
            this.CreateMap<Purchase, PurchaseDTO>();
            this.CreateMap<PurchaseDTO, Purchase>();
        }
    }
}
