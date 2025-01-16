using OnlineShop.Db.Models;


namespace OnlineShop.Db.Interfaces
{
    public interface IFavouriteRepository
    {
        Task<Favourite> AddAsync(Favourite favourite);

        Task<List<Favourite>>? GetAsync(string userId);

        Task<List<Favourite>>? GetByLoginAsync(string userLogin);

        Task<bool> UpdateAsync(Favourite favourite);

        Task<bool> DeleteAsync(string userId);

        Task<bool> DeleteByLoginAsync(string userLogin);

        Task<bool> DeleteByLoginAndFavouriteAsync(string userLogin, Favourite favourite);
    }
}
