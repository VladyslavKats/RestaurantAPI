using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.DAL.Entities
{
    public class Role
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}