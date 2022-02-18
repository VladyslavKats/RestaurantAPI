using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.DAL.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public Collection<User> Users { get; set; }
    }
}