using demo.Enums;
using Microsoft.AspNetCore.Identity;

namespace demo.Helper
{
   public static class ContextSeed
    {
        public static async Task SeedAdminAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new IdentityUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Admin@123");
                    //await userManager.AddToRoleAsync(defaultUser, UserRolesEnum.Executive.ToString());
                }
            }
        }
    }
}
