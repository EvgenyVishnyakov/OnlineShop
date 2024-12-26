using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShopWebApi.Service;

namespace OnlineShopWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UserManagmentController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly UserService _userService;


    public UserManagmentController(UserManager<User> userManager, UserService userService)
    {
        _userManager = userManager;
        _userService = userService;
    }

    [HttpGet("GetUsers")]
    public async Task<IActionResult> Index()
    {
        var usersQuery = await _userManager.Users.ToListAsync();
        if (usersQuery.Count != 0)
            return Ok(usersQuery);
        else
            return BadRequest($"Списка пользователей еще не существует");
    }

    [HttpGet("GetUser")]
    public async Task<IActionResult> Detail(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
            return Ok(user);
        else
            return BadRequest($"Пользователя {userId} еще не существует");
    }

    [HttpPost("AddUser")]
    public async Task<IActionResult> Add(User user)
    {
        var newUser = await _userService.CreateUserAsync(user);
        var result = await _userManager.CreateAsync(newUser, newUser.PasswordHash);
        if (result != null)
            return Ok(result);
        else
            return BadRequest($"Пользователя {user} еще не существует");
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(string userId)
    {
        await _userService.DeleteAsync(userId);
        return Ok();
    }
}
