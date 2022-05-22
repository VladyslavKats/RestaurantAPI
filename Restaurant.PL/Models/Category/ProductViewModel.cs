using System.Collections.Generic;

namespace Restaurant.PL.Models.Category
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public int Weight { get; set; }

        public ICollection<IngredientViewModel> Ingredients { get; set; } = new List<IngredientViewModel>();
    }
}
