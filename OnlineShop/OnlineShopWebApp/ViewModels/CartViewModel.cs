namespace OnlineShopWebApp.ViewModels
{
    public class CartViewModel
    {
        public Guid CartId { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public List<CartItemViewModel> Items { get; set; } = [];

        public decimal TotalCost
        {
            get
            {
                return GetTotal();
            }
        }

        public int Amount
        {
            get
            {
                return Items.Sum(i => i.Quantity);
            }
        }

        public decimal GetTotal()
        {
            return Items?.Sum(i => i.UnitPrice) ?? 0;
        }
    }
}

