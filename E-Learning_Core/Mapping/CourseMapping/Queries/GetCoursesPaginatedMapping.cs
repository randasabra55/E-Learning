using E_Learning_Core.Features.Coursess.Queries.Results;
using E_Learning_Data.Entities;


namespace E_Learning_Core.Mapping.CourseMapping
{
    public partial class CourseProfile
    {
        public void GetCoursesPaginatedMapping()
        {
            CreateMap<Lessons, Lesson>();
            CreateMap<Courses, GetCourseByIdResult>()
                .ForMember(dest => dest.lessons, opt => opt.MapFrom(src => src.lessons));

        }
    }
}
