using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.ViewModels;

public class RoleViewModel
{

    [Required(ErrorMessage = "Введите название")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Название должно содержать от 2 до 30 символов на английском")]
    public string Name { get; set; }

    public List<RoleViewModel> UserRoles { get; set; }

    public override bool Equals(object obj)
    {
        var role = (RoleViewModel)obj;

        return Name == role.Name;
    }
}
