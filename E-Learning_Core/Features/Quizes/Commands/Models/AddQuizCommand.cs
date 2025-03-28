using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Quizes.Commands.Models
{
    public class AddQuizCommand : IRequest<Response<string>>
    {
        public string Title { get; set; }
        public int CourseId { get; set; }
    }
}
