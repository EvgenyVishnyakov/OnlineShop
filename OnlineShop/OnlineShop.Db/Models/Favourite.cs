
using System.Diagnostics.CodeAnalysis;

namespace OnlineShop.Db.Models;


public class Favourite
{
    public Guid Id { get; set; }
    public string TransitionUserId { get; set; }

    [MaybeNull]
    public string? UserName { get; set; }
    public List<Product> FavouriteProducts { get; set; }

    public bool Decrease(Product product)
    {
        if (FavouriteProducts.Exists(x => x.Id == product.Id))
        {
            Delete(FavouriteProducts.Where(x => x.Id == product.Id).First());
            return true;
        }
        else
            return false;
    }

    public void Delete(Product product)
    {
        FavouriteProducts.Remove(product);
    }
}
