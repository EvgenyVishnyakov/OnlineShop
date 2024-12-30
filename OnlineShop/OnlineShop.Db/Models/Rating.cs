namespace OnlineShop.Db.Models
{
    public class Rating
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public double Grade { get; set; }
    }
}
