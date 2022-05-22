using System;

namespace Restaurant.PL.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public bool IsComplete { get; set; }

        public int UserId { get; set; }

        public decimal TotalSum { get; set; }

    }
}
