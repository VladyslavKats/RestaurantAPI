using System.Collections.ObjectModel;

namespace Restaurant.BLL.DTOs
{
    public class IngredientDTO
    {
       
        public int Id { get; set; }

       
        public string Name { get; set; }

        public Collection<ProductDTO> Products { get; set; }
    }
}