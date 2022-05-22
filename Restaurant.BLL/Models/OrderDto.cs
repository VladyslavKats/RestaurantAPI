using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BLL.Models
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public bool IsComplete { get; set; } = false;

        public int UserId { get; set; }

        public decimal TotalSum { get; set; }

        public User User { get; set; }

        public ICollection<OrderDetailDto> OrderDetails { get; set; } = new List<OrderDetailDto>();
    }
}
