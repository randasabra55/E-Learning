using E_Learning_Core.Features.Quizes.Queries.Results;
using E_Learning_Data.Entities;

namespace E_Learning_Core.Mapping.QuizMapping
{
    public partial class QuizProfile
    {
        public void GetQuizByIdMapping()
        {
            // CreateMap<Quizzes, GetQuizResult>();
            CreateMap<Quizzes, GetQuizResult>()
             .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions));

            CreateMap<QuizQuestions, GetQuestionResult>()
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers));

            CreateMap<QuizAnswers, GetAnswerResult>();
        }
    }
}
