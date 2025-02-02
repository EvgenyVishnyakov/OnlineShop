using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Service;
using OnlineShopWebApp.ViewModels;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;

        }

        public IActionResult Index(OrderViewModel orderVM)
        {
            return View(orderVM);
        }

        public async Task<IActionResult> AddAsync(Guid cartId, string userLogin)
        {
            var name = User.Identity!.Name;
            var orderVM = await _orderService.AddCartAsync(cartId, name!);
            return RedirectToAction("Index", orderVM);
        }

        [HttpPost]
        public async Task<IActionResult> BuyAsync([FromForm] OrderViewModel orderVM)
        {
            if (ModelState.IsValid)
            {
                await _orderService.ProcessOrderAsync(orderVM);
                return View();
            }
            return View(orderVM);
        }

        public IActionResult ShowOrder()
        {
            return RedirectToAction("Index");
        }
    }
}
