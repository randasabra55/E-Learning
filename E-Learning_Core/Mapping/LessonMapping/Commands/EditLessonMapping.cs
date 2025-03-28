using E_Learning_Core.Features.Lessonss.Commands.Models;
using E_Learning_Data.Entities;

namespace E_Learning_Core.Mapping.LessonMapping
{
    public partial class LessonProfile
    {
        public void EditLessonMapping()
        {
            CreateMap<EditLessonCommand, Lessons>();
        }
    }
}




