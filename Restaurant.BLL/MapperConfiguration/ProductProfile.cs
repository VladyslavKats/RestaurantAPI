using AutoMapper;
using Restaurant.BLL.DTOs;
using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BLL.MapperConfiguration
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product, ProductDTO>();
            this.CreateMap<ProductDTO, Product>();
        }
    }
}
