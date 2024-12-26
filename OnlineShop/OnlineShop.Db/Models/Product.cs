namespace OnlineShop.Db.Models;


public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int Cost { get; set; }

    public string Description { get; set; }

    public List<Image> Images { get; set; }

    public string Category { get; set; }
}
