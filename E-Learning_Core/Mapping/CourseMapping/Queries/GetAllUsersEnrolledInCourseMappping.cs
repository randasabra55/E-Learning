using E_Learning_Core.Features.Coursess.Queries.Results;
using E_Learning_Data.Entities.Identity;

namespace E_Learning_Core.Mapping.CourseMapping
{
    public partial class CourseProfile
    {
        public void GetAllUsersEnrolledInCourseMappping()
        {
            CreateMap<User, Students>();
            CreateMap<User, GetAllUsersEnrolledInCourseResult>()
            .ForMember(dest => dest.students, opt => opt.MapFrom(src => new List<Students> { new Students { UserName = src.UserName, Email = src.Email } }));

        }
    }
}
