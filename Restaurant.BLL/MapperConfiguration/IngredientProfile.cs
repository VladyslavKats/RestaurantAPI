using AutoMapper;
using Restaurant.BLL.DTOs;
using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BLL.MapperConfiguration
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            this.CreateMap<Ingredient, IngredientDTO>();
            this.CreateMap<IngredientDTO, Ingredient>();
        }
    }
}
