using System.ComponentModel.DataAnnotations;

namespace Restaurant.DAL.Entities
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        public int? OrderId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}