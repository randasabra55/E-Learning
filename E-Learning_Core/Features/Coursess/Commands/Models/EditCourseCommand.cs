using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Coursess.Commands.Models
{
    public class EditCourseCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int InstructorId { get; set; }

    }
}
