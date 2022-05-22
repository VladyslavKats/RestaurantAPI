using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BLL.Models
{
    public class ProductDto
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public decimal Cost { get; set; }

        public int Weight { get; set; }

        public int CategoryId { get; set; }

        public ICollection<IngredientDto> Ingredients { get; set; } = new List<IngredientDto>();

        public CategoryDto Category { get; set; }
    }
}
