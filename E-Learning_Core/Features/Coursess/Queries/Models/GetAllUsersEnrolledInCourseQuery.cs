using E_Learning_Core.Features.Coursess.Queries.Results;
using E_Learning_Core.Wrapper;
using MediatR;

namespace E_Learning_Core.Features.Coursess.Queries.Models
{
    public class GetAllUsersEnrolledInCourseQuery : IRequest<PaginatedResult<GetAllUsersEnrolledInCourseResult>>
    {
        public int CourseId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetAllUsersEnrolledInCourseQuery(int id)
        {
            CourseId = id;
        }
    }
}
