using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces;

public interface ICartsRepository
{
    Task AddAsync(Cart cart);

    Task<Cart?> GetCartByLoginAsync(string userLogin);

    //Task<Cart?> GetByUserIdAsync(string userId);

    Task<Cart?> GetCartByCartIdAsync(Guid cartId);

    Task<List<Cart>> GetAllAsync();

    Task<List<Cart>>? GetAsync(string userId);

    Task AddAttachAsync(Cart cart);

    Task UpdateAsync(Cart cart);

    Task<List<Cart>>? GetByLoginAsync(string userLogin);

    //Task<List<Cart>>? GetByIdAsync(string userId);

    Task DeleteAsync(Guid cartId);

    Task<bool> DeleteAsync(string userId);

    Task<bool> DeleteByLoginAsync(string userLogin);
}
