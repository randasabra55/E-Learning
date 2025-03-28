using E_Learning_Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace E_Learning_Infrastructure.Seeder
{
    public static class RoleSeeder
    {

        public static async Task SeedAsync(RoleManager<Role> roleManager)
        {
            var roleCount = await roleManager.Roles.CountAsync();
            if (roleCount <= 0)
            {
                //await userManager.AddToRoleAsync(User, "User");
                await roleManager.CreateAsync(new Role() { Name = "Student" });
                await roleManager.CreateAsync(new Role() { Name = "Instructor" });
                await roleManager.CreateAsync(new Role() { Name = "Admin" });
            }
        }

    }
}
