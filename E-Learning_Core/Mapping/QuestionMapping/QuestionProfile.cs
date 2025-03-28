using AutoMapper;

namespace E_Learning_Core.Mapping.QuestionMapping
{
    public partial class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            AddQuestionMapping();
            EditQuestionMapping();
            GetQuestionByIdMapping();
            GetQuestionPaginatedMapping();
        }
    }
}
