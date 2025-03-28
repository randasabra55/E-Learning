using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Reviewss.Commands.Models
{
    public class DeleteReviewCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteReviewCommand(int id)
        {
            Id = id;
        }
    }
}
