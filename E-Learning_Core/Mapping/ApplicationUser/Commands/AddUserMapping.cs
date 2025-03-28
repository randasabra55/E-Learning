using E_Learning_Core.Features.Users.Commands.Models;
using E_Learning_Data.Entities.Identity;


namespace E_Learning_Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void AddUserMapping()
        {


            CreateMap<AddUserCommand, User>();
        }
    }
}
