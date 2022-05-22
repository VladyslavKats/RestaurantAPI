using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.DAL.Entities
{
    public class IngredientProduct
    {
        public int IngredientId { get; set; }

        public int ProductId { get; set; }

        public Ingredient Ingredient { get; set; }

        public Product Product { get; set; }
    }
}
