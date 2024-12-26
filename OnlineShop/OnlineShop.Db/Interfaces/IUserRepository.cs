using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);

    Task<User?> GetUserByUserIdAsync(string userId);

    Task<List<User>> GetAllAsync();

    Task<User?> GetUserByUserLoginAsync(string userLogin);

    Task UpdateAsync(User user);

    Task DeleteAsync(Guid userId);
}
