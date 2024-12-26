using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;


namespace OnlineShop.Db.Repository;

public class FavouriteDbRepository : IFavouriteRepository
{
    private readonly DatabaseContext _databaseContext;

    public FavouriteDbRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<Favourite> AddAsync(Favourite favourite)
    {
        try
        {
            await _databaseContext.Favourites.AddAsync(favourite);
            await _databaseContext.SaveChangesAsync();
            return favourite;
        }
        catch
        {
            return null;
        }
    }

    public async Task<Favourite?> GetAsync(string userId)
    {
        var favourite = await _databaseContext.Favourites.Include(x => x.FavouriteProducts).FirstOrDefaultAsync(x => x.UserId == userId);
        return favourite;
    }

    public async Task<bool> UpdateAsync(Favourite favourite)
    {
        _databaseContext.Favourites.Update(favourite);
        await _databaseContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(string userId)
    {
        var favourite = await GetAsync(userId);
        _databaseContext.Favourites.Remove(favourite);
        await _databaseContext.SaveChangesAsync();
        return true;
    }
}

