using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Restaurant.DAL.Entities
{
    public class Ingredient
    {
        
        public int Id { get; set; }

       
        public string Name { get; set; }


        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
