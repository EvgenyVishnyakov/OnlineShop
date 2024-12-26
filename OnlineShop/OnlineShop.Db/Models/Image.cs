namespace OnlineShop.Db.Models;

public class Image
{
    public Guid ImageId { get; set; }

    public Product Product { get; set; }

    public Guid ProductId { get; set; }

    public string ImagesPath { get; set; }

}
