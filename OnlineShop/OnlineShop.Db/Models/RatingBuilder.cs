namespace OnlineShop.Db.Models
{
    public class RatingBuilder
    {
        private Rating _rating = new Rating();

        public RatingBuilder WithId(Guid id)
        {
            _rating.Id = id;
            return this;
        }

        public RatingBuilder WithProductId(Guid productId)
        {
            _rating.ProductId = productId;
            return this;
        }

        public RatingBuilder WithGrade(double grade)
        {
            _rating.Grade = grade;
            return this;
        }

        public Rating Build()
        {
            return _rating;
        }
    }
}
