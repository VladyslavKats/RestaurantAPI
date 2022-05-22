using System.Collections.Generic;

namespace Restaurant.PL.Models
{
    public class CategoryDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductDetailModel> Products { get; set; } = new List<ProductDetailModel>();
    }
}
