﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApi.Models;

public class Authorization
{
    [Required(ErrorMessage = "Укажите Ваш логин")]
    public string Login { get; set; }

    [Required(ErrorMessage = "Укажите пароль")]
    public string Password { get; set; }
}