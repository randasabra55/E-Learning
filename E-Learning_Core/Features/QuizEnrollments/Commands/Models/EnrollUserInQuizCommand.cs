using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.QuizEnrollments.Commands.Models
{
    public class EnrollUserInQuizCommand : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public int QuizId { get; set; }
    }
}
