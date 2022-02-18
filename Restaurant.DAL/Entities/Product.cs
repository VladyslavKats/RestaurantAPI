using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.DAL.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Cost { get; set; }
        [Required]
        public int Weight { get ; set; }

        public int? CategoryId { get; set; }

        public Collection<Ingredient> ingredients { get; set; }

        public Category Category { get; set; }


    }
}