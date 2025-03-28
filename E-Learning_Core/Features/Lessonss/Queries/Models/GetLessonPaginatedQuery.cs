using E_Learning_Core.Features.Lessonss.Queries.Results;
using E_Learning_Core.Wrapper;
using MediatR;

namespace E_Learning_Core.Features.Lessonss.Queries.Models
{
    public class GetLessonPaginatedQuery : IRequest<PaginatedResult<GetLessonResult>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
