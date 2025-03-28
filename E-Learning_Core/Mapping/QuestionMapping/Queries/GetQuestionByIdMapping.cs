using E_Learning_Core.Features.Questions.Queries.Results;
using E_Learning_Data.Entities;

namespace E_Learning_Core.Mapping.QuestionMapping
{
    public partial class QuestionProfile
    {
        public void GetQuestionByIdMapping()
        {
            CreateMap<QuizQuestions, GetQuestionResult>()
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers.Select(a => a.AnswerText)));

        }
    }
}
