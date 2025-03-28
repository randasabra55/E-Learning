using E_Learning_Core.Bases;
using E_Learning_Core.Features.Enrollmentss.Queries.Results;
using MediatR;

namespace E_Learning_Core.Features.Enrollmentss.Queries.Models
{
    public class GetCoursesEnrolledByUserQuery : IRequest<Response<List<GetCoursesEnrolledByUserResult>>>
    {
        public int UserId { get; set; }
        public GetCoursesEnrolledByUserQuery(int id)
        {
            UserId = id;
        }
    }
}
