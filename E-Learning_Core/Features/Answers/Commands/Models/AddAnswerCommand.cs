using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Answers.Commands.Models
{
    public class AddAnswerCommand : IRequest<Response<string>>
    {
        public int QuestionId { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
    public class AnswerDto
    {
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }

    }
}
