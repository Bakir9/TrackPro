using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    AppUserId = 1,
                    FirstName = "Bakir",
                    LastName = "Malkoc",
                    DisplayName ="Bake",
                    UserName = "bakir.malkoc@gmail.com",
                    Email = "bakir.malkoc@gmail.com"
                };

                await userManager.CreateAsync(user,"Pa$$w0rd");
            }
        }
    }
}