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
    public class IngredientService : IIngredientService
    {
        private readonly IRestaurantUW context;
        private readonly IMapper mapper;

        public IngredientService(IRestaurantUW context , IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void Create(IngredientDTO ingredient)
        {
            var item = mapper.Map<IngredientDTO, Ingredient>(ingredient);
            context.Ingredients.Add(item);
        }

        public void Delete(int id)
        {
            context.Ingredients.Delete(id);
        }

        public IngredientDTO Get(int id)
        {
            var item = context.Ingredients.GetById(id);
            return mapper.Map<Ingredient, IngredientDTO>(item);
        }

        public IEnumerable<IngredientDTO> GetAll()
        {
            var items = context.Ingredients.GetAll();
            return mapper.Map<IEnumerable<Ingredient>, IEnumerable<IngredientDTO>>(items);
        }

        public void Save()
        {
            context.Save();
        }

        public void Update(IngredientDTO ingredient)
        {
            var item = mapper.Map<IngredientDTO, Ingredient>(ingredient);
            context.Ingredients.Update(item);
        }
    }
}
