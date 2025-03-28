using E_Learning_Core.Features.Quizes.Queries.Results;
using E_Learning_Core.Wrapper;
using MediatR;

namespace E_Learning_Core.Features.Quizes.Queries.Models
{
    public class GetQuizPaginatedQuery : IRequest<PaginatedResult<GetQuizResult>>
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}
