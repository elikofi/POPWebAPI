using Microsoft.AspNetCore.Identity;

namespace PrinceOfPeace.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string? ProfilePic { get; set; }
    }
}