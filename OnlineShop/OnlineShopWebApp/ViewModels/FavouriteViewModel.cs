namespace OnlineShopWebApp.ViewModels;

public class FavouriteViewModel
{
    public Guid Id { get; set; }
    public string TransitionUserId { get; set; }
    public string? UserName { get; set; }
    public List<ProductViewModel> FavouriteProducts { get; set; }

    public int Amount
    {
        get
        {
            return FavouriteProducts.Count;
        }
    }
}
