using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.DTO;

public class UserWithOutPasswordDto
{
    [Required(ErrorMessage = "Не указан email")]
    [EmailAddress(ErrorMessage = "введите email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Не указан телефон")]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Допускается ввод только положительных чисел")]
    [StringLength(13, MinimumLength = 11, ErrorMessage = "Номер должен содержать минимум 11 и максимум 13 чисел")]
    public string Phone { get; set; }
}