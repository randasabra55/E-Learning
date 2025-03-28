using E_Learning_Core.Features.Users.Queries.Results;
using E_Learning_Core.Wrapper;
using MediatR;

namespace E_Learning_Core.Features.Users.Queries.Models
{
    public class GetUserPaginatedQuery : IRequest<PaginatedResult<GetUserPaginatedList>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
