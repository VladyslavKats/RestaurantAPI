using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BLL.Models
{
    public class OrderDetailDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public OrderDto Order { get; set; }

        public ProductDto Product { get; set; }
    }
}
