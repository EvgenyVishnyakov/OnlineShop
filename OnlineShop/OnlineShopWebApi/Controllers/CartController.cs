using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApi.Service;

namespace OnlineShopWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CartController : Controller
{
    private readonly CartService _cartService;

    public CartController(CartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet("GetCart")]
    public async Task<IActionResult> IndexAsync(string userLogin)
    {
        var cart = await _cartService.GetCartByUserAsync(userLogin);
        if (cart != null)
            return Ok(cart);
        else
            return Ok($"Корзина по пользователю {userLogin} еще не существует");
    }


    [HttpPost("AddProduct")]
    public async Task<IActionResult> AddAsync(Guid productId, string userLogin)
    {
        var result = await _cartService.AddProductAsync(userLogin, productId);

        if (result)
        {
            return Ok(new { Message = $"Товар {productId} успешно добавлен в корзину {userLogin}" });
        }

        return BadRequest($"Возникла ошибка при добавлении товара {productId} в корзину {userLogin}");
    }

    [HttpPost("SubtractionProduct")]
    public async Task<IActionResult> Subtraction(Guid productId, string userLogin)
    {
        var result = await _cartService.DecreaseAmountAsync(userLogin, productId);

        if (result)
        {
            return Ok(new { Message = $"Товар {productId} успешно уменьшен на 1 позицию в корзине {userLogin}" });
        }

        return BadRequest($"Возникла ошибка при уменьшении товара {productId} в корзину {userLogin}");
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> RemoveAsync(Guid cartId)
    {
        var result = await _cartService.DeleteAsync(cartId);
        if (result)
        {
            return Ok(new { Message = $"Корзина {cartId} удалена" });
        }

        return BadRequest($"Ошибка при удалении корзины {cartId}");
    }
}
