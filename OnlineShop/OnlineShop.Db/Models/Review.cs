using OnlineShopWebApp.Helpers;

namespace OnlineShop.Db.Models
{
    public class Review
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid UserId { get; set; }
        public string? Text { get; set; }
        public int Grade { get; set; }
        public DateTime CreateDate { get; set; }
        public ReviewStatus Status { get; set; }
    }
}
