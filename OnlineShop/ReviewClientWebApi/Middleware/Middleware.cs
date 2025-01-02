using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Db.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace OnlineShopWebApi.Middleware;


public class JWTMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public JWTMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context, UserManager<User> userManager)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            await AttachAccountToContextAsync(context, token, userManager);
        }

        await _next(context);
    }

    private async Task AttachAccountToContextAsync(HttpContext context, string token, UserManager<User> userManager)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF32.GetBytes(_configuration["Jwt:Key"]);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidateIssuer = true,
                ValidAudience = _configuration["Jwt:Audience"],
                ValidateAudience = true,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userEmail = jwtToken.Claims.First(x => x.Type == "email").Value;
            var user = await userManager.FindByEmailAsync(userEmail);
            context.Items["User"] = user;
        }
        catch { }
    }
}
