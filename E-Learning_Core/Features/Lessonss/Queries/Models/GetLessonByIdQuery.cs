using E_Learning_Core.Bases;
using E_Learning_Core.Features.Lessonss.Queries.Results;
using MediatR;

namespace E_Learning_Core.Features.Lessonss.Queries.Models
{
    public class GetLessonByIdQuery : IRequest<Response<GetLessonResult>>
    {
        public int Id { get; set; }
        public GetLessonByIdQuery(int id)
        {
            Id = id;
        }
    }
}
