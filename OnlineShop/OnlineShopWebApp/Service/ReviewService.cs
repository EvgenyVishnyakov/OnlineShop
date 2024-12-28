
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using Serilog;

namespace OnlineShopWebApp.Service
{
    public class ReviewService
    {
        private readonly IReviewDbRepository _reviewDbRepository;

        public ReviewService(IReviewDbRepository reviewDbRepository)
        {
            _reviewDbRepository = reviewDbRepository;
        }

        public async Task<List<Review?>> GetAllByProductIdAsync(Guid productId)
        {
            try
            {
                var reviews = await _reviewDbRepository.GetAllByProductIdAsync(productId);
                return reviews;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Отзывов по продукту {productId} нет");
                return null;
            }
        }

        public async Task<Review?> TryGetByIdAsync(Guid reviewId)
        {
            try
            {
                var review = await _reviewDbRepository.TryGetByIdAsync(reviewId);
                return review;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Отзыва {reviewId} нет");
                return null;
            }
        }

        public async Task TryToDeleteAsync(Guid id)
        {
            try
            {
                await _reviewDbRepository.TryToDeleteAsync(id);
                Log.Information($"Отзыв {id} удален");
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Отзыва с id = {id} не существует");
            }
        }

        public async Task<Review> AddAsync(AddReviewDTO addReview)
        {
            var review = CreateReview(addReview);

            await _reviewDbRepository.Reviews.AddAsync(review);
            await _reviewDbRepository.SaveChangesAsync();

            var reviews = await _reviewDbRepository.Reviews.Where(x => x.ProductId == addReview.ProductId).ToListAsync();
            await GetRatingUpdate(addReview, reviews);

            await _reviewDbRepository.SaveChangesAsync();

            return review;

        }

        private async Task GetRatingUpdate(AddReviewDTO addReview, List<Review> reviews)
        {
            var rating = await _databaseContext.Ratings.FirstOrDefaultAsync(x => x.ProductId == addReview.ProductId);

            if (rating != null)
            {
                var averageRating = Math.Round(reviews.Average(x => x.Grade), 2);

                rating.Grade = averageRating;
                rating.CreateDate = DateTime.Now;

                _databaseContext.Ratings.Update(rating);
            }
            else
            {
                rating = new Rating()
                {
                    CreateDate = DateTime.Now,
                    ProductId = addReview.ProductId,
                    Grade = addReview.Grade
                };

                await _databaseContext.Ratings.AddAsync(rating);
            }
        }

        private static Review CreateReview(AddReviewDTO addReview)
        {
            return new Review()
            {
                ProductId = addReview.ProductId,
                UserId = addReview.UserId,
                Text = addReview.Text,
                Grade = addReview.Grade,
                CreateDate = DateTime.Now,
                Status = ReviewStatus.Actual
            };
        }
    }
}
