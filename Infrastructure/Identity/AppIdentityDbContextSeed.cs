using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<User> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new User
                {
                    FirstName = "Bakir",
                    LastName = "Malkoc",
                    UserName = "bakir.malkoc@gmail.com",
                    Email = "bakir.malkoc@gmail.com"
                };

                await userManager.CreateAsync(user,"Pa$$w0rd");
            }
        }
    }
}