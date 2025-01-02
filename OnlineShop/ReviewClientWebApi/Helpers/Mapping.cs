using OnlineShop.Db.Models;
using ReviewClientWebApi.DTO;

namespace ReviewClientWebApi.Helpers
{
    public class Mapping
    {
        public static Review CreateReview(AddReviewDTO addReview)
        {
            return new ReviewBuilder()
                .WithProductId(addReview.ProductId)
                .WithUserId(addReview.UserLogin)
                .WithText(addReview.Text)
                .WithGrade(addReview.Grade)
                .WithCreateDate(addReview.CreateDate)
                .Build();
        }
    }
}
