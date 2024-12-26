namespace OnlineShop.Db.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public string Name { get; set; } = " ";
        public string Address { get; set; } = " ";
        public string Phone { get; set; } = " ";
        public string Email { get; set; } = " ";
        public List<CartItem> Items { get; set; }

        public decimal TotalCost { get; set; }

        public string? OrderNumber { get; set; } = " ";
        public OrderStatus Status { get; set; }
        public string Comment { get; set; } = " ";
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
