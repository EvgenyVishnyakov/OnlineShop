using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApi.Service;

namespace OnlineShopWebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class OrderManagmentController : Controller
{
    private readonly OrderService _orderService;

    public OrderManagmentController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("AddOrders")]
    public async Task<IActionResult> Index()
    {
        var orders = await _orderService.GetOrdersAsync();
        if (orders.Count == 0)
            return Ok(orders);
        else
            return Ok($"Заказов еще нет");
    }

    [HttpPost("UpdateOrderStatus")]
    public async Task<IActionResult> UpdateOrderStatus(Guid orderId, OrderStatus status)
    {
        var result = await _orderService.UpdateOrderStatusAsync(orderId, status);
        if (result)
        {
            return Ok(new { Message = $"Статус заказа {orderId} успешно изменен на {status}" });
        }

        return BadRequest($"Возникла ошибка при обновлении статуса заказа {orderId}");
    }

    [HttpGet("AddOrder")]
    public async Task<IActionResult> GetOrder(Guid orderId)
    {
        var order = await _orderService.GetOrderAsync(orderId);
        if (order != null)
            return Ok(order);
        else
            return Ok($"Заказа {orderId} еще не существует");
    }
}
