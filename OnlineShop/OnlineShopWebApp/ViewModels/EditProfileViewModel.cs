using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace OnlineShopWebApp.ViewModels;

public class EditProfileViewModel
{
    public string Login { get; set; }

    [ValidateNever]
    public string ImageProfile { get; set; }

    [ValidateNever]
    public IFormFile UploadedFile { get; set; }
}
