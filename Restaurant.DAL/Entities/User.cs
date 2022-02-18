using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Restaurant.DAL.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
        
        public int RoleId { get; set; }
        
        
        public string? PhoneNumber { get; set; }

        public Role Role { get; set; }
    }
}
