using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Restaurant.DAL.Entities
{
    public class User
    {
       
        public int Id { get; set; }

        
        public string Login { get; set; }

        
        public string Password { get; set; }
        
        
        public int RoleId { get; set; }
        
        
        public string PhoneNumber { get; set; }

       
        public Role Role { get; set; }


        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
