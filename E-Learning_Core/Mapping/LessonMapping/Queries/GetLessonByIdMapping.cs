using E_Learning_Core.Features.Lessonss.Queries.Results;
using E_Learning_Data.Entities;

namespace E_Learning_Core.Mapping.LessonMapping
{
    public partial class LessonProfile
    {
        public void GetLessonByIdMapping()
        {
            CreateMap<Lessons, GetLessonResult>()
                .ForMember(dest => dest.CourseTitle, opt => opt.MapFrom(src => src.courses.Title))
                .ForMember(dest => dest.CourseDescription, opt => opt.MapFrom(src => src.courses.Description));
        }
    }
}
