using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repository;

public class OrderRepository : IOrdersRepository
{
    private readonly DatabaseContext _databaseContext;

    public OrderRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task AddAsync(Order order)
    {
        _databaseContext.Orders.Attach(order);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _databaseContext.Orders
            .AsNoTracking()
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .ToListAsync();
    }

    public async Task<bool> UpdateAsync(Order order)
    {
        try
        {
            _databaseContext.Orders.Update(order);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> UpdateStatusAsync(Order order)
    {
        _databaseContext.Orders.Update(order);
        await _databaseContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateOrderStatusAsync(Guid orderId, OrderStatus status)
    {
        var orders = await GetAllAsync();
        var order = orders.FirstOrDefault(x => x.OrderId == orderId);
        order.Status = status;
        await UpdateStatusAsync(order);
        return true;
    }

    public async Task<bool> AddOrderNumberAsync(Order order, string newCounter)
    {
        order.OrderNumber = newCounter;
        return true;
    }

    public async Task<Order> GetOrderAsync(Guid orderId)
    {
        var orders = await GetAllAsync();
        var order = orders.FirstOrDefault(x => x.OrderId == orderId);
        return order;
    }
}

