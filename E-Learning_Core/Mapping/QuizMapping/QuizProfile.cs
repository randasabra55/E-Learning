using AutoMapper;

namespace E_Learning_Core.Mapping.QuizMapping
{
    public partial class QuizProfile : Profile
    {
        public QuizProfile()
        {
            AddQuizMapping();
            EditQuizMapping();
            GetQuizByIdMapping();
            GetQuizPaginatedMapping();
        }
    }
}
