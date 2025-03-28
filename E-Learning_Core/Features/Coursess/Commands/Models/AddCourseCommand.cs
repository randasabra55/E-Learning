using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Coursess.Commands.Models
{
    public class AddCourseCommand : IRequest<Response<string>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int InstructorId { get; set; }
    }
}
