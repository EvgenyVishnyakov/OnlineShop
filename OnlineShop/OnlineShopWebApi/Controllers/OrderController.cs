using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApi.Service;

namespace OnlineShopWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;

        }

        [HttpPost("AddCart")]
        public async Task<IActionResult> AddAsync(Guid cartId, string userLogin)
        {
            var result = await _orderService.AddCartAsync(cartId, userLogin);
            if (result)
            {
                return Ok(new { Message = $"Корзина {cartId} успешно добавлен в заказ" });
            }

            return BadRequest($"Возникла ошибка при добавлении корзины {cartId} в заказ");
        }
    }
}
