using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces;

public interface ICartsRepository
{
    Task AddAsync(Cart cart);

    Task<Cart?> GetCartByLoginAsync(string userLogin);

    //Task<Cart?> GetByUserIdAsync(string userId);

    Task<Cart?> GetCartByCartIdAsync(Guid cartId);

    Task<List<Cart>> GetAllAsync(string userId);

    Task<Cart>? GetAsync(string userId);

    Task AddAttachAsync(Cart cart);

    Task UpdateAsync(Cart cart);

    Task<Cart>? GetByLoginAsync(string userLogin);

    Task DeleteAsync(Guid cartId);

    Task<bool> DeleteAsync(string userId);

    Task<bool> DeleteByLoginAsync(string userLogin);

    Task DeleteCartAsync(Cart cart);
}
