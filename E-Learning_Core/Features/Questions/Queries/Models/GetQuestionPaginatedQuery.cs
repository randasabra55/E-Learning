using E_Learning_Core.Features.Questions.Queries.Results;
using E_Learning_Core.Wrapper;
using MediatR;

namespace E_Learning_Core.Features.Questions.Queries.Models
{
    public class GetQuestionPaginatedQuery : IRequest<PaginatedResult<GetQuestionResult>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
