using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface IRatingDbRepository
    {
        Task<Rating> GetRating(Guid productId);

        Task AddAsync(Rating newRating);

        Task UpdateAsync(Rating rating);
    }
}
