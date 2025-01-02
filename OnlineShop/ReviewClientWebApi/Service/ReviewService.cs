
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using ReviewClientWebApi.DTO;
using ReviewClientWebApi.Helpers;
using Serilog;

namespace ReviewClientWebApi.Service
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

        public async Task<bool> TryToDeleteAsync(Guid id, string userName)
        {
            try
            {
                var user = await _userRepository.GetUserByUserLoginAsync(userName);
                var userId = user.Id;
                await _reviewDbRepository.TryToDeleteAsync(id, userId);
                Log.Information($"Отзыв {id} удален");
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Отзыва с id = {id} не существует");
                return false;
            }
        }

        public async Task<bool> AddAsync(AddReviewDTO addReview)
        {
            try
            {
                addReview.CreateDate = DateTime.Now;
                var reviews = await GetAllByProductIdAsync(addReview.ProductId);
                var product = await _productService.GetAsync(addReview.ProductId);

                var reviewDb = Mapping.CreateReview(addReview);
                reviewDb.ProductName = product.Name;
                var ratingDb = await GetRatingUpdate(reviewDb, reviews);
                product.Grade = ratingDb.Grade;
                await _reviewDbRepository.AddAsync(reviewDb);
                await _productService.UpdateAsync(product);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Отзыв не добавлен");
                return false;
            }
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
    }
}
