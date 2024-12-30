using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repository
{
    public class RatingDbRepository : IRatingDbRepository
    {
        private readonly DatabaseContext _databaseContext;

        public RatingDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Rating> GetRating(Guid productId)
        {
            var ratings = await _databaseContext.Ratings.ToListAsync();
            var rating = ratings.FirstOrDefault(x => x.ProductId == productId);
            return rating;
        }

        public async Task AddAsync(Rating newRating)
        {
            await _databaseContext.AddAsync(newRating);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Rating rating)
        {
            _databaseContext.Ratings.Update(rating);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
