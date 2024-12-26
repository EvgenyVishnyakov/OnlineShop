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

    public async Task<Cart?> GetByUserIdAsync(string userId)
    {
        return await _databaseContext.Carts
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.IsActive == "true");
    }

    public async Task<Cart?> GetCartByCartIdAsync(Guid cartId)
    {
        return await _databaseContext.Carts
            .AsNoTracking()
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.CartId == cartId);
    }

    public async Task<List<Cart>> GetAllAsync()
    {
        return await _databaseContext.Carts.ToListAsync();
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
}
