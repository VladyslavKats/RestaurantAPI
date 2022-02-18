using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.EF;
using Restaurant.DAL.Entities;
using Restaurant.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.DAL.Data
{
    public class IngredientRepository : GenericRepository<Ingredient> , IIngredientRepository
    {
        public IngredientRepository(RestaurantDbContext context) : base(context, context.Ingredients)
        {
            
        }

    }
}
