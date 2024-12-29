
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

        public ReviewService(IReviewDbRepository reviewDbRepository, IUserRepository userRepository)
        {
            _reviewDbRepository = reviewDbRepository;
            _userRepository = userRepository;
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
            var reviewDb = Mapping.CreateReview(addReview);
            await _reviewDbRepository.AddAsync(reviewDb);

            //var reviews = await _reviewDbRepository.Reviews.Where(x => x.ProductId == addReview.ProductId).ToListAsync();
            //await GetRatingUpdate(addReview, reviews);

            //await _reviewDbRepository.SaveChangesAsync();
        }

        //private async Task GetRatingUpdate(AddReviewDTO addReview, List<Review> reviews)
        //{
        //    var rating = await _databaseContext.Ratings.FirstOrDefaultAsync(x => x.ProductId == addReview.ProductId);

        //    if (rating != null)
        //    {
        //        var averageRating = Math.Round(reviews.Average(x => x.Grade), 2);

        //        rating.Grade = averageRating;
        //        rating.CreateDate = DateTime.Now;

        //        _databaseContext.Ratings.Update(rating);
        //    }
        //    else
        //    {
        //        rating = new Rating()
        //        {
        //            CreateDate = DateTime.Now,
        //            ProductId = addReview.ProductId,
        //            Grade = addReview.Grade
        //        };

        //        await _databaseContext.Ratings.AddAsync(rating);
        //    }
        //}       
    }
}
