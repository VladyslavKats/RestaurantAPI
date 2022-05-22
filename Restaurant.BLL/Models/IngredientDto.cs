using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BLL.Models
{
    public class IngredientDto
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
