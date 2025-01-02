using ReviewClientWebApi.Models;

namespace ReviewClientWebApi.Interfaces;

public interface IAccountService
{
    Task<bool> IsValidLoginAsync(Authorization user);
    Task<bool> IsValidUser(Registration data);
}