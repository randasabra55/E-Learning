using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Enrollmentss.Commands.Models
{
    public class EnrollStudentCommand : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
    }
}
