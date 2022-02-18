using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BLL.DTOs
{
    public class CategoryDTO
    {
       
        public int Id { get; set; }

       
        public string Name { get; set; }

        public ICollection<ProductDTO> Products { get; set; }
    }
}
