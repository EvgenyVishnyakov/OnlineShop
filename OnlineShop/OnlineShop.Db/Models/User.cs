using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Db.Models
{
    public class User : IdentityUser
    {
        public Guid TransitionUserId { get; set; } = Guid.NewGuid();
        public string? ProfileImage { get; set; }
    }
}
