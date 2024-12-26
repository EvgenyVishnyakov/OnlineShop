namespace OnlineShopWebApp.ViewModels;

public class EditRightsVM
{
    public string UserId { get; set; }
    public string UserName { get; set; }

    public List<RoleViewModel>? UserRoles { get; set; }

    public List<RoleViewModel>? AllRoles { get; set; }
}
