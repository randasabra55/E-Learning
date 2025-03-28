using E_Learning_Core.Features.Enrollmentss.Queries.Results;

namespace E_Learning_Core.Mapping.EnrollmentMapping
{
    public partial class EnrollmentProfile
    {
        public void GetCourseEnrolledMapping()
        {
            CreateMap<string, GetCoursesEnrolledByUserResult>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src)); ;
        }
    }
}
