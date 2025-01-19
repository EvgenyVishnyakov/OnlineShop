
using System.Diagnostics.CodeAnalysis;

namespace OnlineShop.Db.Models;

public class Cart
{
    public Guid CartId { get; set; }
    //public string UserId { get; set; }

    public string TransitionUserId { get; set; }

    [MaybeNull]
    public string? UserName { get; set; }
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
        var item = Items.First(x => x.Product.Id == product.Id);
        if (item != null)
        {
            if (item.Quantity == 1)
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

