using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Lessonss.Commands.Models
{
    public class DeleteLessonCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteLessonCommand(int id)
        {
            Id = id;
        }
    }
}
