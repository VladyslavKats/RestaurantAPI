using System.Collections.Generic;

namespace Restaurant.PL.Models.Category
{
    public class CategoryDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }

    }
}
