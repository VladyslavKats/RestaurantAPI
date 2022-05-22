using AutoMapper;
using Restaurant.BLL.Models;
using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BLL
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<IngredientDto , Ingredient>().ReverseMap();
            CreateMap<CategoryDto , Category>().ReverseMap();
            

            CreateMap<ProductDto, Product>().ReverseMap();
               
               
            CreateMap<OrderDto , Order>().ReverseMap();
            CreateMap<OrderDetailDto , OrderDetail>().ReverseMap();
        }
        
    }
}
