using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.DAL.Entities
{
    public class Product
    {
        
        public int Id { get; set; }

      
        public string Name { get; set; }

        
        public decimal Cost { get; set; }
       
        public int Weight { get ; set; }

        public int? CategoryId { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public Category Category { get; set; }


    }
}