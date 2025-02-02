
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.DTO;
using OnlineShopWebApp.Helpers;
using Serilog;

namespace OnlineShopWebApp.Service
{
    public class ReviewService
    {
        private readonly IReviewDbRepository _reviewDbRepository;
        private readonly IUserRepository _userRepository;
        private readonly ProductService _productService;
        private readonly IRatingDbRepository _ratingDbRepository;

        public ReviewService(IReviewDbRepository reviewDbRepository, IUserRepository userRepository,
            ProductService productService, IRatingDbRepository ratingDbRepository)
        {
            _reviewDbRepository = reviewDbRepository;
            _userRepository = userRepository;
            _productService = productService;
            _ratingDbRepository = ratingDbRepository;
        }

        public async Task<List<Review?>> GetReviewsByProductIdAsync(Guid productId)
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

        public async Task TryToDeleteAsync(Guid id, string userName)
        {
            try
            {
                var user = await _userRepository.GetUserByUserLoginAsync(userName);
                var userId = user.Id;
                await _reviewDbRepository.TryToDeleteAsync(id, userId);
                Log.Information($"Отзыв {id} удален");
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Отзыва с id = {id} не существует");
            }
        }

        public async Task AddAsync(AddReviewDTO addReview)
        {
            var reviews = await GetReviewsByProductIdAsync(addReview.ProductId);
            var product = await _productService.GetAsync(addReview.ProductId);

            var reviewDb = Mapping.CreateReview(addReview);
            reviewDb.ProductName = product.Name;
            var ratingDb = await GetRatingUpdate(reviewDb, reviews);
            product.Grade = ratingDb.Grade;
            await _reviewDbRepository.AddAsync(reviewDb);
            await _productService.UpdateAsync(product);
        }

        private async Task<Rating> GetRatingUpdate(Review review, List<Review> reviews)
        {
            var rating = await _ratingDbRepository.GetRating(review.ProductId);

            if (rating != null)
            {
                var averageRating = Math.Round(reviews.Average(x => x.Grade), 2);
                rating.Grade = averageRating;
                await _ratingDbRepository.UpdateAsync(rating);
                return rating;
            }
            else
            {
                rating = new Rating()
                {
                    Id = Guid.NewGuid(),
                    ProductId = review.ProductId,
                    Grade = review.Grade
                };

                await _ratingDbRepository.AddAsync(rating);
                return rating;
            }
        }

        public async Task<Rating?> GetRatingByProductIdAsync(Guid productId)
        {
            try
            {
                var rating = await _ratingDbRepository.GetRating(productId);
                return rating;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Ошибка получения рейтинга для продукта по Id {productId}");
                return null;
            }
        }
    }
}
