using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Db.Models
{
    public class User : IdentityUser
    {
        public string Id { get; set; }
        public Guid TempUserId { get; set; } = Guid.NewGuid();
        public string? ProfileImage { get; set; }
    }
}
