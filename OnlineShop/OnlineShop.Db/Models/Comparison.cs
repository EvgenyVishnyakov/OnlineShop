
using System.Diagnostics.CodeAnalysis;

namespace OnlineShop.Db.Models;

public class Comparison
{
    public Guid Id { get; set; }
    public string TransitionUserId { get; set; }

    [MaybeNull]
    public string? UserName { get; set; }
    public List<Product>? ComparisonProducts { get; set; }

    public bool Decrease(Product product)
    {
        if (ComparisonProducts.Exists(x => x.Id == product.Id))
        {

            Delete(ComparisonProducts.Where(x => x.Id == product.Id).First());
            return true;
        }
        else
            return false;
    }

    public void Delete(Product product)
    {
        ComparisonProducts.Remove(product);
    }
}


