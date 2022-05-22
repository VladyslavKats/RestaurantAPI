using System;
using System.Collections.Generic;

namespace Restaurant.PL.Models
{
    public class OrderDetailModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public bool IsComplete { get; set; }

        public int UserId { get; set; }

        public decimal TotalSum { get; set; }

        public ICollection<OrderDetailViewModel> OrderDetails { get; set; } = new List<OrderDetailViewModel>();
    }
}
