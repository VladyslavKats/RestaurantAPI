using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Restaurant.BLL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public bool IsComplete { get; set; } = false;

        public int UserId { get; set; }

        public decimal TotalSum { get; set; }

        public UserDTO User { get; set; }
        public Collection<PurchaseDTO> Purchases { get; set; }
    }
}
