using Restaurant.BLL.Models;
using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Restaurant.PL.Models
{
    public class OrderCreateModel
    {
       
        public int UserId { get; set; }

        public ICollection<OrderDetailCreateModel> OrderDetails { get; set; } = new List<OrderDetailCreateModel>();
    }
}
