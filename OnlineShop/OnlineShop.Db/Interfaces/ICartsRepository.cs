using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces;

public interface ICartsRepository
{
    Task AddAsync(Cart cart);

    Task<Cart?> GetByUserIdAsync(string userId);

    Task<Cart?> GetCartByCartIdAsync(Guid cartId);

    Task<List<Cart>> GetAllAsync();

    Task AddAttachAsync(Cart cart);

    Task UpdateAsync(Cart cart);

    Task DeleteAsync(Guid cartId);
}
