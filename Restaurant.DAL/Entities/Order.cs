using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Restaurant.DAL.Entities
{
    public class Order
    {
        
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public bool IsComplete { get; set; } = false;

        public int? UserId { get; set; }

        public decimal TotalSum { get; set; }

        public User User { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();   
    }
}
