using System.Collections.ObjectModel;

namespace Restaurant.BLL.DTOs
{
    public class ProductDTO
    {
      
        public int Id { get; set; }

        public string Name { get; set; }

        
        public decimal Cost { get; set; }
       
        public int Weight { get; set; }

        public int? CategoryId { get; set; }

        public Collection<IngredientDTO> ingredients { get; set; }

        public CategoryDTO Category { get; set; }
    }
}