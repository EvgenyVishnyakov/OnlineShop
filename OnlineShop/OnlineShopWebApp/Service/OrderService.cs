using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.ViewModels;
using Serilog;

namespace OnlineShopWebApp.Service
{
    public class OrderService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly CartService _cartService;
        private readonly CartItemService _cartItemService;
        private readonly UserManager<User> _userManager;


        public OrderService(IOrdersRepository ordersRepository, CartService cartService, UserManager<User> userManager, CartItemService cartItemService)
        {
            _ordersRepository = ordersRepository;
            _cartService = cartService;
            _userManager = userManager;
            _cartItemService = cartItemService;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _ordersRepository.GetAllAsync();
        }

        public async Task<string> GetUserIdAsync(string userLogin)
        {
            var user = await _userManager.FindByEmailAsync(userLogin);

            var userId = await _userManager.GetUserIdAsync(user);

            return userId;
        }

        public async Task<List<OrderViewModel>> GetOrdersAsync()
        {
            try
            {
                var orders = await _ordersRepository.GetAllAsync();
                var ordersVM = Mapping.ToOrderViewModels(orders);
                return ordersVM;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка добавления заказов");
                return null;
            }
        }

        public async Task<OrderViewModel> AddCartAsync(Guid cartId, string userLogin)
        {
            try
            {

                var cart = await _cartService.GetAsync(cartId);

                var order = await CreateAsync(userLogin, cart);
                var orderVM = Mapping.ToOrderViewModel(order);
                orderVM.Email = userLogin;

                Log.Information($"В заказ {order.OrderId} добавлена корзина с ID: {cartId}");
                return orderVM;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка добавления корзины в заказ");
                return null;
            }
        }

        public async Task<OrderViewModel?> GetOrderAsync(Guid orderId)
        {
            try
            {
                var orders = await _ordersRepository.GetAllAsync();
                var order = orders.FirstOrDefault(x => x.OrderId == orderId);
                var orderVM = Mapping.ToOrderViewModel(order);

                return orderVM;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка получения заказа из списка");
                return null;
            }
        }

        public async Task<OrderViewModel?> GetOrderByUserAsync(Guid orderId, string userLogin)
        {
            try
            {
                var order = await _ordersRepository.GetOrderAsync(orderId);
                var orderVM = Mapping.ToOrderViewModel(order);
                orderVM.Email = userLogin;
                return orderVM;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка получения заказа из списка");
                return null;
            }
        }

        public async Task DeleteAsync(Guid cartId)
        {
            try
            {
                await _cartService.DeleteAsync(cartId);
                Log.Information($"Продолжаем оформление заказа после успешного удаления корзины");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка удаления корзины из списка");
            }
        }

        public async Task ProcessOrderAsync(OrderViewModel orderViewModel)
        {
            try
            {
                var order = await _ordersRepository.GetOrderAsync(orderViewModel.OrderId);
                var newOrder = Mapping.FromOrderViewModel(orderViewModel, order);
                await _ordersRepository.UpdateAsync(newOrder);

                Log.Information($"Создан заказ под номером {newOrder.OrderNumber}");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка создания заказа");
            }
        }

        public async Task UpdateOrderStatusAsync(Guid orderId, OrderStatus newStatus)
        {
            try
            {
                await _ordersRepository.UpdateOrderStatusAsync(orderId, newStatus);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка обновления заказа");
            }
        }

        public async Task<string> GetOrderNumberAsync(Guid orderId)
        {
            try
            {
                var orders = await _ordersRepository.GetAllAsync();
                var order = orders.LastOrDefault();
                Log.Information($"Получен номер для заказа");
                return GeneratorNumberForOrder.GetOrderNumber(order, orderId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка создания заказа");
                return "";
            }
        }

        private async Task<Order> CreateAsync(string userLogin, Cart cart)
        {
            try
            {
                var userId = await GetUserIdAsync(userLogin);

                var newOrder = new Order();
                var newOrderCounter = await GetOrderNumberAsync(Guid.NewGuid());
                await _ordersRepository.AddOrderNumberAsync(newOrder, newOrderCounter);
                newOrder.Email = userLogin;

                await CreateNewOrderAsync(newOrder, cart);
                await _ordersRepository.AddAsync(newOrder);

                await _cartItemService.UpdateAsync(newOrder.Items);

                await DeleteAsync(cart.CartId);

                Log.Information($"Создан новый заказ под номером {newOrderCounter}");
                return newOrder;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка создания заказа");
                return null;
            }
        }

        private async Task CreateNewOrderAsync(Order newOrder, Cart cart)
        {
            newOrder.Status = OrderStatus.Created;
            newOrder.CreatedDateTime = DateTime.Now;
            newOrder.Items = cart.Items;
        }
    }
}
