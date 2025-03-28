using E_Learning_Core.Bases;
using E_Learning_Core.Features.Search.Queries.Models;
using E_Learning_Core.Features.Search.Queries.Results;
using E_Learning_Core.Wrapper;
using MediatR;

namespace E_Learning_Core.Features.Search.Queries.Handlers
{
    public class SearchQueryHandler : ResponseHandler,
                                    IRequestHandler<SearchCourseByNameQuery, PaginatedResult<SearchResult>>,
                                    IRequestHandler<SearchCourseByInstructorNameQuery, PaginatedResult<SearchResult>>,
                                    IRequestHandler<SearchCourseByDateQuery, PaginatedResult<SearchResult>>
    {
        public Task<PaginatedResult<SearchResult>> Handle(SearchCourseByNameQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedResult<SearchResult>> Handle(SearchCourseByInstructorNameQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedResult<SearchResult>> Handle(SearchCourseByDateQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
