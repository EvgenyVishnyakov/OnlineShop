using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Service;

namespace OnlineShopWebApp.Views.Shared.Components.Account;

public class AccountViewComponent : ViewComponent
{
    private readonly AccountService _accountService;

    public AccountViewComponent(AccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string Name)
    {
        var model = await _accountService.GetUserVMAsync(Name);
        return View("AccountImage", model);
    }
}
