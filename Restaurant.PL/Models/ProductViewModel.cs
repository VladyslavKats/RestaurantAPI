namespace Restaurant.PL.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string  Name { get; set; }

        public decimal Cost { get; set; }

        public int Weight { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}
