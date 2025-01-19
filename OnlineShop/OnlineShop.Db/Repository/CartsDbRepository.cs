using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repository;

public class CartsDbRepository : ICartsRepository
{
    private readonly DatabaseContext _databaseContext;

    public CartsDbRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task AddAsync(Cart cart)
    {
        _databaseContext.Carts.Add(cart);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<Cart?> GetCartByLoginAsync(string userLogin)
    {
        return await _databaseContext.Carts
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.UserName == userLogin && x.IsActive == "true");
    }

    public async Task<Cart?> GetCartByCartIdAsync(Guid cartId)
    {
        return await _databaseContext.Carts
            .AsNoTracking()
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.CartId == cartId);
    }

    public async Task<List<Cart>> GetAllAsync(string userId)
    {
        return await _databaseContext.Carts
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .Where(x => x.TransitionUserId == userId && x.IsActive == "true").ToListAsync();
    }

    public async Task AddAttachAsync(Cart cart)
    {
        _databaseContext.Carts.Update(cart);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Cart cart)
    {
        _databaseContext.Carts.AttachRange(cart);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid cartId)
    {
        var cart = await _databaseContext.Carts.Include(x => x.Items).FirstAsync(x => x.CartId == cartId);
        if (cart != null)
        {
            cart.IsActive = "false";
            _databaseContext.Carts.Update(cart);
            await _databaseContext.SaveChangesAsync();
        }
    }

    public async Task<bool> DeleteAsync(string userId)
    {
        var cart = await GetAsync(userId);
        _databaseContext.Carts.Remove(cart);
        await _databaseContext.SaveChangesAsync();
        return true;
    }

    public async Task<Cart>? GetAsync(string userId)
    {
        var cart = await _databaseContext.Carts
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.TransitionUserId == userId && x.IsActive == "true");
        return cart;
    }

    public async Task<Cart>? GetByLoginAsync(string userLogin)
    {
        var cart = await _databaseContext.Carts
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.UserName == userLogin && x.IsActive == "true");
        return cart;
    }

    public async Task<bool> DeleteByLoginAsync(string userLogin)
    {
        var cart = await GetByLoginAsync(userLogin);
        _databaseContext.Carts.Remove(cart);
        await _databaseContext.SaveChangesAsync();
        return true;
    }

    public async Task DeleteCartAsync(Cart cart)
    {
        _databaseContext.Carts.Remove(cart);
        await _databaseContext.SaveChangesAsync();
    }
}
