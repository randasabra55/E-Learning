using E_Learning_Core.Features.Users.Queries.Results;
using E_Learning_Data.Entities.Identity;

namespace E_Learning_Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void GetUserById()
        {
            CreateMap<User, GetUserByIdResponse>();
        }
    }
}
