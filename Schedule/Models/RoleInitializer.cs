using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Schedule.Models
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            string[] admins = new string[]
            {
                "rus.gumeniuk@gmail.com",
                "pass w0Rd",
                "oleg@gmail.com",
                "p@ssW0rd"
            };
            for (int i = 0; i < 3; i += 2)
            {
                if (await userManager.FindByNameAsync(admins[i]) == null)
                {
                    User admin = new User { Email = admins[i], UserName = admins[i] };
                    IdentityResult result = await userManager.CreateAsync(admin, admins[i + 1]);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(admin, "admin");
                    }
                }
            }
        }
    }
}
