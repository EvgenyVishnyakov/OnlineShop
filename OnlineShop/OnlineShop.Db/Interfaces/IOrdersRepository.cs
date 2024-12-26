using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetAllAsync();

        Task AddAsync(Order order);

        Task<bool> UpdateAsync(Order order);

        Task<bool> UpdateStatusAsync(Order order);

        Task<bool> UpdateOrderStatusAsync(Guid orderId, OrderStatus status);

        Task<bool> AddOrderNumberAsync(Order order, string newCounter);

        Task<Order> GetOrderAsync(Guid orderId);
    }
}
