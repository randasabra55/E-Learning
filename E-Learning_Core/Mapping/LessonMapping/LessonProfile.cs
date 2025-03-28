using AutoMapper;

namespace E_Learning_Core.Mapping.LessonMapping
{
    public partial class LessonProfile : Profile
    {
        public LessonProfile()
        {
            AddLessonMapping();
            EditLessonMapping();
            GetLessonByIdMapping();
            GetLessonPaginatedMapping();
        }
    }
}
