using AutoMapper;
using E_Learning_Core.Bases;
using E_Learning_Core.Features.Lessonss.Queries.Models;
using E_Learning_Core.Features.Lessonss.Queries.Results;
using E_Learning_Core.Wrapper;
using E_Learning_Service.Abstracts;
using MediatR;

namespace E_Learning_Core.Features.Lessonss.Queries.Handlers
{
    public class LessonQueryHandler : ResponseHandler,
                                    IRequestHandler<GetLessonByIdQuery, Response<GetLessonResult>>,
                                    IRequestHandler<GetLessonPaginatedQuery, PaginatedResult<GetLessonResult>>
    {
        ILessonService lessonService;
        IMapper mapper;
        public LessonQueryHandler(ILessonService lessonService, IMapper mapper)
        {
            this.mapper = mapper;
            this.lessonService = lessonService;
        }
        public async Task<Response<GetLessonResult>> Handle(GetLessonByIdQuery request, CancellationToken cancellationToken)
        {
            var lesson = await lessonService.GetLessonByIdIncludingCourse(request.Id);
            if (lesson == null)
                return NotFound<GetLessonResult>("this lesson not found");
            //map
            var result = mapper.Map<GetLessonResult>(lesson);
            return Success(result);
        }

        public async Task<PaginatedResult<GetLessonResult>> Handle(GetLessonPaginatedQuery request, CancellationToken cancellationToken)
        {
            var lessons = lessonService.GetLessonPaginatedIncludingCourse();
            //map
            var result = await mapper.ProjectTo<GetLessonResult>(lessons)
                         .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }
    }
}
