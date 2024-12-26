using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.ViewModels;

public class AccountViewModel
{
    public string UserId { get; set; }

    [Required(ErrorMessage = "Не указан email")]
    [EmailAddress(ErrorMessage = "введите email")]
    public string Login { get; set; }

    [Required(ErrorMessage = "Не указан телефон")]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Допускается ввод только положительных чисел")]
    [StringLength(13, MinimumLength = 11, ErrorMessage = "Номер должен содержать минимум 11 и максимум 13 чисел")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Не указан пароль")]
    [RegularExpression(@"(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[!\\+,-_\.\@])[a-zA-Z0-9!\\+,-_\.\@]{8,}", ErrorMessage = "Пароль должен содержать не менее 8 знаков" +
            " минимум одну заглавную букву, " +
            "минимум одну цифру, и минимум один из следующих символов: -._@+\\\",и не должен совпадать с Email")]
    public string Password { get; set; }

    public string? ProfileImage { get; set; }
}
