using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.ViewModels
{
    public class RoleVM
    {
        [Required(ErrorMessage = "Введите название")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Название должно содержать от 2 до 30 символов на английском")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Введите значение")]
        //[StringLength(30, MinimumLength = 2, ErrorMessage = "Значение должно содержать от 2 до 30 символов на русском")]
        //public string? Value { get; set; }
    }
}
