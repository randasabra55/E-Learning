using AutoMapper;
using E_Learning_Core.Bases;
using E_Learning_Core.Features.Questions.Queries.Models;
using E_Learning_Core.Features.Questions.Queries.Results;
using E_Learning_Core.Wrapper;
using E_Learning_Service.Abstracts;
using MediatR;

namespace E_Learning_Core.Features.Questions.Queries.Handlers
{
    public class QuestionQueryHandler : ResponseHandler,
                                      IRequestHandler<GetQuestionByIdQuery, Response<GetQuestionResult>>,
                                      IRequestHandler<GetQuestionPaginatedQuery, PaginatedResult<GetQuestionResult>>
    {
        IQuestionService questionService;
        IMapper mapper;
        public QuestionQueryHandler(IQuestionService questionService, IMapper mapper)
        {
            this.questionService = questionService;
            this.mapper = mapper;
        }

        public async Task<Response<GetQuestionResult>> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await questionService.GetQuestionById(request.Id);
            if (result == null)
                return NotFound<GetQuestionResult>($"this question with id {request.Id} not found");
            //mapp
            var resultMapping = mapper.Map<GetQuestionResult>(result);
            return Success(resultMapping);
        }

        public async Task<PaginatedResult<GetQuestionResult>> Handle(GetQuestionPaginatedQuery request, CancellationToken cancellationToken)
        {
            var list = questionService.GetPaginatedQuestion();
            var paginatedList = await mapper.ProjectTo<GetQuestionResult>(list)
                                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
    }
}
