using OnlineShop.Db.Models;


namespace OnlineShop.Db.Interfaces
{
    public interface IFavouriteRepository
    {
        Task<Favourite> AddAsync(Favourite favourite);

        Task<Favourite?> GetAsync(string userId);

        Task<bool> UpdateAsync(Favourite favourite);

        Task<bool> DeleteAsync(string userId);
    }
}
