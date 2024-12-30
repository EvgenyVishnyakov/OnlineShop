namespace OnlineShop.Db.Models;


public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int Cost { get; set; }

    public string Description { get; set; }

    public List<Image> Images { get; set; }

    public string Category { get; set; }

    public double Grade { get; set; }

    public Rating Rating { get; set; }

    public List<Review> Reviews { get; set; } = new List<Review>();
}
