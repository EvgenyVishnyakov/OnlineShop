namespace OnlineShopWebApp.ViewModels;

public class ComparisonViewModel
{
    public Guid Id { get; set; }
    public string TransitionUserId { get; set; }
    public string? UserName { get; set; }
    public List<ProductViewModel> ComparisonProducts { get; set; }

    public int Amount
    {
        get
        {
            return ComparisonProducts.Count;
        }
    }
}
