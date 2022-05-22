using System.Collections.Generic;

namespace Restaurant.PL.Models
{
    public class ProductDetailModel
    {
       
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public int Weight { get; set; }

        public int CategoryId { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public ICollection<IngredientViewModel> Ingredients { get; set; } = new List<IngredientViewModel>();
    }
}
