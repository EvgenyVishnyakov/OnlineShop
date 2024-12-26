using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineShopWebApi.Service;
using Authorization = OnlineShopWebApi.Models.Authorization;
using Registration = OnlineShopWebApi.Models.Registration;
namespace OnlineShopWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IAccountService _userService;

    public AccountController(IConfiguration configuration, IAccountService userService)
    {
        _configuration = configuration;
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("IsValidLogin")]
    public async Task<IActionResult> Login([FromBody] Authorization user)
    {
        var result = await _userService.IsValidLoginAsync(user);

        if (result)
        {
            var tokenString = await GenerateJwtTokenAsync(user.Login);

            return Ok(new { Token = tokenString, Message = "Success" });
        }

        return BadRequest("Пожалуйста, укажите правильный логин и пароль");
    }

    [AllowAnonymous]
    [HttpPost("Registration")]
    public async Task<IActionResult> Register([FromBody] Registration user)
    {
        var result = await _userService.IsValidUser(user);

        if (result)
        {
            var tokenString = await GenerateJwtTokenAsync(user.Email);

            return Ok(new { Token = tokenString, Message = "Success" }); ;
        }

        return BadRequest($"{user.Email} уже существует. Введите другой email");
    }

    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("getResult")]
    public IActionResult GetResult()
    {
        return Ok("API Validated");
    }

    private async Task<string> GenerateJwtTokenAsync(string userName)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF32.GetBytes(_configuration["Jwt:key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([new Claim("email", userName)]),
            Expires = DateTime.UtcNow.AddHours(24),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}