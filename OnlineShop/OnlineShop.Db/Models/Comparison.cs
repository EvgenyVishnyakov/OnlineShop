
namespace OnlineShop.Db.Models;

public class Comparison
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public List<Product>? ComparisonProducts { get; set; }

    public void Decrease(Product product)
    {
        if (ComparisonProducts.Exists(x => x.Id == product.Id))
        {

            Delete(ComparisonProducts.Where(x => x.Id == product.Id).First());

        }
    }

    public void Delete(Product product)
    {
        ComparisonProducts.Remove(product);
    }
}


