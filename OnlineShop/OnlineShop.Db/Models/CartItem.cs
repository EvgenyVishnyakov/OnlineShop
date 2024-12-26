namespace OnlineShop.Db.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public decimal UnitPrice
        {
            get
            {
                return Product.Cost * Quantity;
            }
        }
    }
}
