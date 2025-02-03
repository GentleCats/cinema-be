using cinema_be.Entities;
using Microsoft.AspNetCore.Identity;

namespace cinema_be
{
    public static class SeederDB
    {
        public static async Task SeedData(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();


            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new Role { Name = "Member" });
                await roleManager.CreateAsync(new Role { Name = "Admin" });

                var user = new User
                {
                    UserName = "Stepan",
                    Email = "StenNepan@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString() 
                };

                await userManager.CreateAsync(user, "User123!");
                await userManager.AddToRoleAsync(user, "Member");

                var admin = new User
                {
                    UserName = "Admin",
                    Email = "admin@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString() 
                };

                await userManager.CreateAsync(admin, "Admin123!");
                await userManager.AddToRolesAsync(admin, new[] { "Member", "Admin" });
            }

        }
    }
}