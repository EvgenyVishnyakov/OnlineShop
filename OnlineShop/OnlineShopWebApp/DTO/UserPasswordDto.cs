using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.DTO
{
    public class UserPasswordDto
    {
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [RegularExpression(@"(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[!\\+,-_\.\@])[a-zA-Z0-9!\\+,-_\.\@]{8,}", ErrorMessage = "Пароль должен содержать не менее 8 знаков" +
            " минимум одну заглавную букву, " +
            "минимум одну цифру, и минимум один из следующих символов: -._@+\\\",и не должен совпадать с Email")]//_sS123456
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан пароль для подтверждения")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }

        public string Email { get; set; }
    }
}
