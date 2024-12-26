using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApi.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage = "введите Ваш email")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Пароль должен содержать не менее 8 знаков")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
