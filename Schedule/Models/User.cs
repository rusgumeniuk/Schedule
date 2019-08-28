using Microsoft.AspNetCore.Identity;

namespace Schedule.Models
{
    public class User : IdentityUser
    {
        public string GroupName { get; set; }
    }
}
