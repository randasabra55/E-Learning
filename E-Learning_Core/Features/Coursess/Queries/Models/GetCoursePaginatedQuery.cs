using E_Learning_Core.Features.Coursess.Queries.Results;
using E_Learning_Core.Wrapper;
using MediatR;

namespace E_Learning_Core.Features.Coursess.Queries.Models
{
    public class GetCoursePaginatedQuery : IRequest<PaginatedResult<GetCourseByIdResult>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string? CourseName { get; set; }
        public string? InstructorName { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
    }
}
