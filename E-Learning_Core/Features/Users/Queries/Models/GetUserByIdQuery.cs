using E_Learning_Core.Bases;
using E_Learning_Core.Features.Users.Queries.Results;
using MediatR;

namespace E_Learning_Core.Features.Users.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
