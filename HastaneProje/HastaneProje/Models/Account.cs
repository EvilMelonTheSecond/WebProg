using Microsoft.AspNetCore.Identity;

namespace HastaneProje.Models
{
    public class Account : IdentityUser
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
