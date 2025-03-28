using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Questions.Commands.Models
{
    public class DeleteQuestionCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteQuestionCommand(int id)
        {
            Id = id;
        }
    }
}
