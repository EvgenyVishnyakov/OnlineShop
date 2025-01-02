using System.ComponentModel.DataAnnotations;

namespace ReviewClientWebApi.Models;

public class Registration
{
    [Required(ErrorMessage = "Введите Ваш e-mail")]
    [EmailAddress(ErrorMessage = "Вы ввели неккоретный адрес почты")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Введите номер телефона")]
    [Phone(ErrorMessage = "Указан неккоректный номер телефона")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Укажите пароль")]
    [StringLength(15, MinimumLength = 11, ErrorMessage = "Длина пароля должна быть от 11 до 15 символов")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Повторите пароль")]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    public string ConfirmPassword { get; set; }


}
