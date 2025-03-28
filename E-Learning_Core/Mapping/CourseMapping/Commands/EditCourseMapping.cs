using E_Learning_Core.Features.Coursess.Commands.Models;
using E_Learning_Data.Entities;

namespace E_Learning_Core.Mapping.CourseMapping
{
    public partial class CourseProfile
    {
        public void EditCourseMapping()
        {
            CreateMap<EditCourseCommand, Courses>();
        }
    }
}
