using E_Learning_Core.Bases;
using E_Learning_Core.Features.Coursess.Queries.Results;
using MediatR;

namespace E_Learning_Core.Features.Coursess.Queries.Models
{
    public class GetCourseByIdQuery : IRequest<Response<GetCourseByIdResult>>
    {
        public int Id { get; set; }
        public GetCourseByIdQuery(int id)
        {
            Id = id;
        }
    }
}
