using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Coursess.Commands.Models
{
    public class DeleteCourseCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteCourseCommand(int id)
        {
            Id = id;
        }
    }
}
