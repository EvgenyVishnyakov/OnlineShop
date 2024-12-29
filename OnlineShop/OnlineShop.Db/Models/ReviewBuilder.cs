using OnlineShopWebApp.Helpers;

namespace OnlineShop.Db.Models
{
    public class ReviewBuilder
    {
        private Review _review = new Review();

        public ReviewBuilder WithId(Guid id)
        {
            _review.Id = id;
            return this;
        }

        public ReviewBuilder WithProductId(Guid productId)
        {
            _review.ProductId = productId;
            return this;
        }

        public ReviewBuilder WithUserId(string userId)
        {
            _review.UserId = userId;
            return this;
        }

        public ReviewBuilder WithText(string text)
        {
            _review.Text = text;
            return this;
        }

        public ReviewBuilder WithGrade(int grade)
        {
            _review.Grade = grade;
            return this;
        }

        public ReviewBuilder WithCreateDate(DateTime createDate)
        {
            _review.CreateDate = createDate;
            return this;
        }

        public ReviewBuilder WithReviewStatus(ReviewStatus reviewStatus)
        {
            _review.Status = reviewStatus;
            return this;
        }

        public Review Build()
        {
            return _review;
        }
    }
}
