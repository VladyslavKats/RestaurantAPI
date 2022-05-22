namespace Restaurant.PL.Models
{
    public class ProductCreateModel
    {
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public int Weight { get; set; }

        public int CategoryId { get; set; }
    }
}
