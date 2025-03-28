using E_Learning_Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_Learning_Core.Features.Lessonss.Commands.Models
{
    public class AddLessonCommand : IRequest<Response<string>>
    {
        public string Title { get; set; }
        public IFormFile VideoUrl { get; set; }
        public int Order { get; set; }//ترتيب الدرس
        public int CourseId { get; set; }
    }
}
