namespace OnlineShopWebApi.Models;

public class ImagesProvider
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private string firstPartPath = "/Images/";

    public ImagesProvider(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
}
