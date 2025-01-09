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
        await _databaseContext.Favourites.AddAsync(favourite);
        await _databaseContext.SaveChangesAsync();
        return favourite;
    }

    public async Task<List<Favourite>>? GetAsync(string userId)
    {
        var favourites = await _databaseContext.Favourites.Include(x => x.FavouriteProducts).Where(x => x.TransitionUserId == userId).ToListAsync();
        return favourites;
    }

    public async Task<List<Favourite>>? GetByLoginAsync(string userLogin)
    {
        var favourites = await _databaseContext.Favourites.Include(x => x.FavouriteProducts).Where(x => x.UserName == userLogin).ToListAsync();
        return favourites;
    }


    public async Task<bool> UpdateAsync(Favourite favourite)
    {
        _databaseContext.Favourites.Update(favourite);
        await _databaseContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(string userId)
    {
        var favourites = await GetAsync(userId);
        foreach (var favourite in favourites)
        {
            _databaseContext.Favourites.Remove(favourite);
            await _databaseContext.SaveChangesAsync();
        }
        return true;
    }

    public async Task<bool> DeleteByLoginAsync(string userLogin)
    {
        var favourites = await GetByLoginAsync(userLogin);
        foreach (var favourite in favourites)
        {
            _databaseContext.Favourites.Remove(favourite);
            await _databaseContext.SaveChangesAsync();
        }
        return true;
    }
}

