using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Service;

namespace OnlineShopWebApp.Areas.Admin.Controllers;

[Area(Constants.AdminRoleName)]
[Authorize(Roles = Constants.AdminRoleName)]
public class OrderManagmentController : Controller
{
    private readonly OrderService _orderService;

    public OrderManagmentController(OrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<IActionResult> Index()
    {
        var ordersVM = await _orderService.GetOrdersAsync();
        return View(ordersVM);
    }

    public async Task<IActionResult> UpdateOrderStatus(Guid orderId, OrderStatus Status)
    {
        await _orderService.UpdateOrderStatusAsync(orderId, Status);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> GetOrder(Guid orderId)
    {
        var order = await _orderService.GetOrderAsync(orderId);
        return View(order);
    }
}
