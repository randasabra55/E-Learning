using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Quizes.Commands.Models
{
    public class DeleteQuizCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteQuizCommand(int id)
        {
            Id = id;
        }

    }
}
