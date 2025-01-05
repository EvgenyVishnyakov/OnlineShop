using System.ComponentModel.DataAnnotations;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.DTO
{
    public class LoginModelDTO
    {
        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage = "введите Ваш email")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Пароль должен содержать не менее 8 знаков")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }

    }
}
