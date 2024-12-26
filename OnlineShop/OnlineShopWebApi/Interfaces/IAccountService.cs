using OnlineShopWebApi.Models;

namespace OnlineShopWebApi.Service;

public interface IAccountService
{
    Task<bool> IsValidLoginAsync(Authorization user);
    Task<bool> IsValidUser(Registration data);
}