using AutoMapper;
using E_Learning_Core.Bases;
using E_Learning_Core.Features.Quizes.Queries.Models;
using E_Learning_Core.Features.Quizes.Queries.Results;
using E_Learning_Core.Wrapper;
using E_Learning_Service.Abstracts;
using MediatR;

namespace E_Learning_Core.Features.Quizes.Queries.Handlers
{
    public class QuizQueryHandler : ResponseHandler,
                                      IRequestHandler<GetQuizByIdQuery, Response<GetQuizResult>>,
                                      IRequestHandler<GetQuizPaginatedQuery, PaginatedResult<GetQuizResult>>
    {
        IQuizeService quizeService;
        IMapper mapper;
        public QuizQueryHandler(IQuizeService quizeService, IMapper mapper)
        {
            this.quizeService = quizeService;
            this.mapper = mapper;
        }
        public async Task<Response<GetQuizResult>> Handle(GetQuizByIdQuery request, CancellationToken cancellationToken)
        {
            var quiz = await quizeService.GetQuizById(request.Id);
            if (quiz == null)
                return NotFound<GetQuizResult>();
            //map
            var result = mapper.Map<GetQuizResult>(quiz);
            return Success(result);
        }

        public async Task<PaginatedResult<GetQuizResult>> Handle(GetQuizPaginatedQuery request, CancellationToken cancellationToken)
        {
            var list = quizeService.GetQuizzessAsync();
            var paginatedList = await mapper.ProjectTo<GetQuizResult>(list)
                                    .ToPaginatedListAsync(request.pageNumber, request.pageSize);
            return paginatedList;
        }
    }
}
