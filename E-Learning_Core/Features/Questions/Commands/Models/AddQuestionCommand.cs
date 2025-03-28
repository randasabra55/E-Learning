using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Questions.Commands.Models
{
    public class AddQuestionCommand : IRequest<Response<string>>
    {
        public string Question { get; set; }
        public int QuizId { get; set; }

    }
}
