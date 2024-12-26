using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Helpers;

public class ImagesProvider
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private string firstPartPath = "/Images/";

    public ImagesProvider(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<List<string>> SaveFilesAsync(IFormFile[] formFiles, ImageFolder folder)
    {
        var imagePaths = new List<string>();
        foreach (var file in formFiles)
        {
            var imagePath = await SaveFileAsync(file, folder);
            imagePaths.Add(imagePath);
        }
        return imagePaths;

    }

    private async Task<string> SaveFileAsync(IFormFile file, ImageFolder folder)
    {
        if (file != null)
        {
            string folderPath = Path.Combine(_webHostEnvironment.WebRootPath + firstPartPath + folder);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var fileName = Guid.NewGuid() + "." + file.FileName.Split('.').Last();
            var path = Path.Combine(folderPath, fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return firstPartPath + folder + "/" + fileName;
        }
        return null;
    }

    public async Task<string> SaveProfileAsync(IFormFile file, ImageFolder folder)
    {
        if (file != null)
        {
            string folderPath = Path.Combine(_webHostEnvironment.WebRootPath + firstPartPath + folder);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var fileName = Guid.NewGuid() + "." + file.FileName.Split('.').Last();
            var path = Path.Combine(folderPath, fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return firstPartPath + folder + "/" + fileName;
        }
        return null;
    }
}
