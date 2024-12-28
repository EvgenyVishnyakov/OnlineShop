using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;


namespace OnlineShop.Db.Repository;

public class ReviewDbRepository : IReviewDbRepository
{
    private readonly DatabaseContext _databaseContext;

    public ReviewDbRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<List<Review?>> GetAllAsync()
    {
        return await _databaseContext.Reviews.ToListAsync();
    }

    public async Task<List<Review?>> GetAllByProductIdAsync(Guid productId)
    {
        var reviews = await _databaseContext.Reviews.Where(x => x.ProductId == productId).ToListAsync();
        return reviews;
    }

    public async Task AddAsync(Review newReview)
    {
        _databaseContext.Reviews.Add(newReview);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<Review?> TryGetByIdAsync(Guid reviewId)
    {
        var review = await _databaseContext.Reviews.FirstOrDefaultAsync(x => x.Id == reviewId);
        return review;
    }

    public async Task TryToDeleteAsync(Guid id)
    {
        var reviews = await GetAllAsync();
        var review = reviews.FirstOrDefault(x => x.Id == id);
        review.Status = ReviewStatus.Deleted;
        UpdateAsync(review);
    }

    public async Task UpdateAsync(Review review)
    {
        _databaseContext.Reviews.Update(review);
        await _databaseContext.SaveChangesAsync();
    }
}
