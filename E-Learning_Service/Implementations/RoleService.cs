using E_Learning_Data.Entities.Identity;
using E_Learning_Service.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace E_Learning_Service.Implementations
{
    public class RoleService : IRoleService
    {
        UserManager<User> userManager;
        public RoleService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<string> EditRole(int userId, string name)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return $"this user with id {userId} not fount";

            var oldRole = await userManager.GetRolesAsync(user);
            if (oldRole.Any())
            {
                var roleRemovalResult = await userManager.RemoveFromRolesAsync(user, oldRole);
                if (!roleRemovalResult.Succeeded)
                {
                    return "Failed to remove old roles";
                }
            }

            user.Role = name;
            var result = await userManager.AddToRoleAsync(user, name);
            if (!result.Succeeded)
            {
                return "Failed to assign this role to this user";
            }
            return "Assigning role to user is successfully";
            //throw new NotImplementedException();
        }

        public async Task<string> DeleteRole(int userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return $"this user with id {userId} not fount";

            var oldRole = await userManager.GetRolesAsync(user);
            var roleRemovalResult = await userManager.RemoveFromRolesAsync(user, oldRole);
            if (!roleRemovalResult.Succeeded)
                return "Failed to delete this role";
            user.Role = "";
            await userManager.UpdateAsync(user);
            return "Role deleted successfully";


        }
    }
}
