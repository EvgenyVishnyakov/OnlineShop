using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repository;

public class UserDbRepository : IUserRepository
{
    private readonly DatabaseContext _identityContext;

    public UserDbRepository(DatabaseContext identityContext)
    {
        _identityContext = identityContext;
    }

    public async Task AddAsync(User user)
    {
        _identityContext.Users.Add(user);
        await _identityContext.SaveChangesAsync();
    }

    public async Task<User?> GetUserByUserIdAsync(string userId)
    {
        return await _identityContext.Users
            .FirstOrDefaultAsync(x => x.Id == userId);
    }

    public async Task<User?> GetUserByUserLoginAsync(string userLogin)
    {
        return await _identityContext.Users
            .FirstOrDefaultAsync(x => x.UserName == userLogin);
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _identityContext.Users.ToListAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _identityContext.Users.Update(user);
        await _identityContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid userId)
    {
        var user = await _identityContext.Users.FirstOrDefaultAsync(x => x.Id == userId.ToString());
        if (user != null)
        {
            _identityContext.Users.Remove(user);
            await _identityContext.SaveChangesAsync();
        }
    }
}
