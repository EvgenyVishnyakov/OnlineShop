using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.ViewModels;

namespace OnlineShopWebApp.Service;

public class AccountService
{
    private readonly UserManager<User> _userManager;
    private readonly ImagesProvider _imagesProvider;
    private readonly OrderService _orderService;
    private readonly string imagePath = "/Images/Пустая_аватарка.png";

    public AccountService(UserManager<User> userManager, ImagesProvider imagesProvider, OrderService orderService)
    {
        _userManager = userManager;
        _imagesProvider = imagesProvider;
        _orderService = orderService;
    }

    public async Task<AccountViewModel> GetUserAsync(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        var userVM = Mapping.ToAccountVM(user);
        return userVM;
    }

    public async Task<EditProfileViewModel> EditAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var userVM = Mapping.ToAccountEditProfile(user);
        return userVM;
    }

    public async Task<User> EditProfileAsync(EditProfileViewModel modelVM)
    {
        var user = await _userManager.FindByNameAsync(modelVM.Login);
        var addedImagesPaths = await _imagesProvider.SaveProfileAsync(modelVM.UploadedFile, ImageFolder.Profiles);
        modelVM.ImageProfile = addedImagesPaths;
        return Mapping.FromAccountEditProfile(user, modelVM);
    }

    public async Task<User> DeleteAsync(EditProfileViewModel modelVM)
    {
        var user = await _userManager.FindByNameAsync(modelVM.Login);
        modelVM.ImageProfile = imagePath;
        return Mapping.FromAccountEditProfile(user, modelVM);
    }

    public async Task<List<AccountOrderViewModel>> GetOrdersAsync(string userLogin)
    {
        var orders = await _orderService.GetAllAsync();
        var ordersListByUser = orders.Where(x => x.Email == userLogin).ToList();
        var accountOrdersViewModel = Mapping.ToAccountOrdersViewModel(ordersListByUser);
        return accountOrdersViewModel;
    }

    public async Task<UserVM> GetUserVMAsync(string Name)
    {
        var userDB = await _userManager.FindByNameAsync(Name);
        if (userDB != null)
        {
            return new UserVM
            {
                ImagePath = userDB.ProfileImage
            };
        }
        else
            return null;

    }
}
