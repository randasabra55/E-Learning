using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.QuizEnrollments.Commands.Models
{
    public class AddUserAnswerCommand : IRequest<Response<string>>
    {
        public int UserQuizAttemptId { get; set; }
        public List<UserAnswerDto> Answers { get; set; }
    }
    public class UserAnswerDto
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}
