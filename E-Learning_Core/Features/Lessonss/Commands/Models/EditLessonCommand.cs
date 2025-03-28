using E_Learning_Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_Learning_Core.Features.Lessonss.Commands.Models
{
    public class EditLessonCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public IFormFile VideoUrl { get; set; }
        public int Order { get; set; }
    }
}
