namespace OnlineShopWebApp.ViewModels
{
    public class ComparisonViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<ProductViewModel> ComparisonProducts { get; set; }

        public int Amount
        {
            get
            {
                return ComparisonProducts.Count;
            }
        }
    }
}
