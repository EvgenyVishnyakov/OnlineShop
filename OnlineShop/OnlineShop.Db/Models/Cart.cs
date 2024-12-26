
namespace OnlineShop.Db.Models;

public class Cart
{
    public Guid CartId { get; set; }
    public string UserId { get; set; }
    public string IsActive { get; set; }
    public List<CartItem> Items { get; set; }

    public decimal TotalCost
    {
        get
        {
            return GetTotal();
        }
    }

    public Cart()
    {
        Items = new List<CartItem>();
        IsActive = "true";
    }

    public async Task AddItemAsync(Product product)
    {
        if (Items.Exists(x => x.Product.Id == product.Id))
        {
            Items.Where(x => x.Product.Id == product.Id).FirstOrDefault().Quantity++;
            return;
        }

        Items.Add(new CartItem { Product = product, Quantity = 1 });
    }

    public void DecreaseCount(Product product)
    {
        if (Items.Exists(x => x.Product.Id == product.Id))
        {
            if (Items.Exists(x => x.Quantity == 1))
            {
                Delete(Items.Where(x => x.Product.Id == product.Id).First());
                return;
            }

            Items.Where(x => x.Product.Id == product.Id).First().Quantity--;
        }
    }

    public void Delete(CartItem cartItem)
    {
        Items.Remove(cartItem);
    }

    public decimal GetTotal()
    {
        return Items?.Sum(i => i.UnitPrice) ?? 0;
    }
}

