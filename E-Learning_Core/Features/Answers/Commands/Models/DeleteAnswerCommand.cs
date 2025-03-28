using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Answers.Commands.Models
{
    public class DeleteAnswerCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteAnswerCommand(int id)
        {
            Id = id;
        }
    }
}
