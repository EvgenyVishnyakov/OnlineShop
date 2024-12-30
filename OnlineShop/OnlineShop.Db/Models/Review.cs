using OnlineShopWebApp.Helpers;

namespace OnlineShop.Db.Models
{
    public class Review
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string ProductName { get; set; }
        public string UserId { get; set; }
        public string? Text { get; set; }
        public int Grade { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public ReviewStatus Status { get; set; }

        public string GetName(Product product)
        {
            return ProductName = product.Name;
        }
    }
}
