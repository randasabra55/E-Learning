using E_Learning_Core.Features.QuizEnrollments.Commands.Models;
using E_Learning_Data.Entities;

namespace E_Learning_Core.Mapping.QuizEnrollmentMapping
{
    public partial class QuizEnrollmentProfile
    {
        public void AddStudentAnswerMapping()
        {
            CreateMap<UserAnswerDto, UserQuizAnswers>()
                .ForMember(dest => dest.QuestionId, opt => opt.MapFrom(src => src.QuestionId))
                .ForMember(dest => dest.AnswerId, opt => opt.MapFrom(src => src.AnswerId));

            CreateMap<AddUserAnswerCommand, List<UserQuizAnswers>>()
                .ConvertUsing((src, dest, context) =>
                    src.Answers.Select(answer => new UserQuizAnswers
                    {
                        UserQuizAttemptId = src.UserQuizAttemptId,
                        QuestionId = answer.QuestionId,
                        AnswerId = answer.AnswerId
                    }).ToList());

        }
    }
}


