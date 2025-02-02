//using System.Text.Json.Serialization;// на критичный случай отказа в старте при первом запуске

namespace OnlineShop.Db.Models;

public class Image
{
    public Guid ImageId { get; set; }

    //[JsonIgnore]// на критичный случай отказа в старте при первом запуске
    public Product Product { get; set; }

    public Guid ProductId { get; set; }

    public string ImagesPath { get; set; }
}
