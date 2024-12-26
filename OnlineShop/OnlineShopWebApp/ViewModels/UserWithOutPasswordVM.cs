using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.ViewModels
{
    public class UserWithOutPasswordVM
    {
        [ValidateNever]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage = "введите email")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан телефон")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Допускается ввод только положительных чисел")]
        [StringLength(13, MinimumLength = 11, ErrorMessage = "Номер должен содержать минимум 11 и максимум 13 чисел")]
        public string PhoneNumber { get; set; }
    }
}
