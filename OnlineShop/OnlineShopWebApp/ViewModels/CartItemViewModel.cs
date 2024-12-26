namespace OnlineShopWebApp.ViewModels
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public ProductViewModel Product { get; set; }
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
