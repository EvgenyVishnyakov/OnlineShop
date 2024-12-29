using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface IReviewDbRepository
    {
        Task<List<Review?>> GetAllAsync();

        Task<List<Review?>> GetAllByProductIdAsync(Guid productId);

        Task AddAsync(Review newReview);

        Task<Review?> TryGetByIdAsync(Guid reviewId);

        Task TryToDeleteAsync(Guid id, string userId);

        Task UpdateAsync(Review review);
    }
}