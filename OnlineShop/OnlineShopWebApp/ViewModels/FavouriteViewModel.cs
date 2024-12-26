namespace OnlineShopWebApp.ViewModels;

public class FavouriteViewModel
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public List<ProductViewModel> FavouriteProducts { get; set; }

    public int Amount
    {
        get
        {
            return FavouriteProducts.Count;
        }
    }
}
