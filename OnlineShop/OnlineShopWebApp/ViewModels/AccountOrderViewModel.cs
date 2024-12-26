using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.ViewModels;

public class AccountOrderViewModel
{

    public List<CartItem> Items { get; set; }

    public string? Comment { get; set; }

    public OrderStatus Status { get; set; }

    [ValidateNever]
    public string OrderNumber { get; set; }

    [BindNever]
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    public decimal TotalCost { get; set; }
}
