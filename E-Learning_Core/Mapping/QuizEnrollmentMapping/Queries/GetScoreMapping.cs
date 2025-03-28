using E_Learning_Core.Features.QuizEnrollments.Queries.Results;
using E_Learning_Data.Entities;

namespace E_Learning_Core.Mapping.QuizEnrollmentMapping
{
    public partial class QuizEnrollmentProfile
    {
        public void GetScoreMapping()
        {
            CreateMap<UserQuizzes, GetScoreResult>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Quizzes.Title))
            .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score))
            .ForMember(dest => dest.AttemptedAt, opt => opt.MapFrom(src => src.AttemptedAt));
        }
    }
}
