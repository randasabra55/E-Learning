using AutoMapper;
using E_Learning_Core.Bases;
using E_Learning_Core.Features.Coursess.Queries.Models;
using E_Learning_Core.Features.Coursess.Queries.Results;
using E_Learning_Core.Wrapper;
using E_Learning_Data.Requests;
using E_Learning_Service.Abstracts;
using MediatR;

namespace E_Learning_Core.Features.Coursess.Queries.Handlers
{
    public class CourseQueryHandler : ResponseHandler,
                                      IRequestHandler<GetCourseByIdQuery, Response<GetCourseByIdResult>>,
                                      IRequestHandler<GetCoursePaginatedQuery, PaginatedResult<GetCourseByIdResult>>,
                                      IRequestHandler<GetAllUsersEnrolledInCourseQuery, PaginatedResult<GetAllUsersEnrolledInCourseResult>>
    {
        ICourseService courseService;
        IMapper mapper;
        public CourseQueryHandler(ICourseService courseService, IMapper mapper)
        {
            this.courseService = courseService;
            this.mapper = mapper;
        }
        public async Task<Response<GetCourseByIdResult>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await courseService.GetCourseByIdAsync(request.Id);
            if (result == null)
                return NotFound<GetCourseByIdResult>($"this course with id {request.Id} not found");
            //mapp
            var resultMapping = mapper.Map<GetCourseByIdResult>(result);
            return Success(resultMapping);
        }

        public async Task<PaginatedResult<GetCourseByIdResult>> Handle(GetCoursePaginatedQuery request, CancellationToken cancellationToken)
        {
            var requestDto = new GetCoursePaginatedRequest
            {
                CourseName = request.CourseName,
                InstructorName = request.InstructorName,
                Description = request.Description,
                Date = request.Date
            };
            var list = courseService.GetCoursesAsync(requestDto);
            var paginatedList = await mapper.ProjectTo<GetCourseByIdResult>(list)
                                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }

        public async Task<PaginatedResult<GetAllUsersEnrolledInCourseResult>> Handle(GetAllUsersEnrolledInCourseQuery request, CancellationToken cancellationToken)
        {
            var users = courseService.GetAllUsersInrolledInCourse(request.CourseId);
            var result = await mapper.ProjectTo<GetAllUsersEnrolledInCourseResult>(users)
                                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }
    }

}
