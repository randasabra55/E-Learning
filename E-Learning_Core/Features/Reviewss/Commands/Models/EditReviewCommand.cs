using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Reviewss.Commands.Models
{
    public class EditReviewCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
