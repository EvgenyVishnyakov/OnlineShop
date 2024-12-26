using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OnlineShop.Db.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.ViewModels;

public class OrderViewModel
{
    public Guid OrderId { get; set; }

    [Required(ErrorMessage = "Введите имя")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Имя должно содержать от 2 до 30 символов")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Введите адресс")]
    [StringLength(100, MinimumLength = 15, ErrorMessage = "Адрес должен содержать улицу и дом")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Не указан телефон")]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Допускается ввод только положительных чисел")]
    [StringLength(13, MinimumLength = 11, ErrorMessage = "Номер должен содержать минимум 11 и максимум 13 чисел")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Не указан email")]
    [EmailAddress(ErrorMessage = "введите Ваш email")]
    public string Email { get; set; }

    public List<CartItem> Items { get; set; }

    public string? Comment { get; set; }

    public OrderStatus Status { get; set; }

    [ValidateNever]
    public string OrderNumber { get; set; }

    [BindNever]
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    public decimal TotalCost { get; set; }

}
