using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Reviewss.Commands.Models
{
    public class AddReviewCommand : IRequest<Response<string>>
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
    }
}
