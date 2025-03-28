using AutoMapper;
using E_Learning_Core.Bases;
using E_Learning_Core.Features.Reviewss.Queries.Models;
using E_Learning_Core.Features.Reviewss.Queries.Results;
using E_Learning_Core.Wrapper;
using E_Learning_Service.Abstracts;
using MediatR;

namespace E_Learning_Core.Features.Reviewss.Queries.Handlers
{
    public class ReviewQueryHandler : ResponseHandler,
                                      IRequestHandler<GetReviewsPaginatedAboutCourseQuery, PaginatedResult<GetReviewsPaginatedResult>>

    {
        IReviewService reviewService;
        ICourseService courseService;
        IMapper mapper;
        public ReviewQueryHandler(IReviewService reviewService, IMapper mapper, ICourseService courseService)
        {
            this.reviewService = reviewService;
            this.mapper = mapper;
            this.courseService = courseService;
        }

        public async Task<PaginatedResult<GetReviewsPaginatedResult>> Handle(GetReviewsPaginatedAboutCourseQuery request, CancellationToken cancellationToken)
        {
            var course = await courseService.GetCourseByIdAsync(request.CourseId);
            /*if (course != null)
            {*/
            //return ( "$\"thete is no course with id {request.CourseId} to find reviews" );
            var reviews = reviewService.GetReviewsByCourseIdQuerable(request.CourseId);
            //map
            var result = await mapper.ProjectTo<GetReviewsPaginatedResult>(reviews)
                                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
            // }
        }
    }
}
