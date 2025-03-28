using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Answers.Commands.Models
{
    public class EditAnswerCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }

        //public int QuestionId { get; set; }
    }
}
