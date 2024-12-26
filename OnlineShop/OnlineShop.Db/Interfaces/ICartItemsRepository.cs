using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface ICartItemsRepository
    {
        Task Update(CartItem cartItem);
    }
}
