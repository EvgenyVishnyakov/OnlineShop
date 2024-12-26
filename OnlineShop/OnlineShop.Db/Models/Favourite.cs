
namespace OnlineShop.Db.Models;


public class Favourite
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public List<Product> FavouriteProducts { get; set; }

    public async Task DecreaseAsync(Product product)
    {
        if (FavouriteProducts.Exists(x => x.Id == product.Id))
        {
            Delete(FavouriteProducts.Where(x => x.Id == product.Id).First());
        }
    }

    public void Delete(Product product)
    {
        FavouriteProducts.Remove(product);
    }
}
