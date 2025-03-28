using E_Learning_Core.Features.Reviewss.Queries.Results;
using E_Learning_Core.Wrapper;
using MediatR;

namespace E_Learning_Core.Features.Reviewss.Queries.Models
{
    public class GetReviewsPaginatedAboutCourseQuery : IRequest<PaginatedResult<GetReviewsPaginatedResult>>
    {
        public int CourseId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetReviewsPaginatedAboutCourseQuery(int id)
        {
            CourseId = id;
        }
    }
}
