namespace Restaurant.BLL.DTOs
{
    public class PurchaseDTO
    {
        public int Id { get; set; }

        public int? OrderId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public OrderDTO Order { get; set; }
        public ProductDTO Product { get; set; }
    }
}