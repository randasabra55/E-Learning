using AutoMapper;
using E_Learning_Core.Bases;
using E_Learning_Core.Features.Coursess.Commands.Models;
using E_Learning_Data.Entities;
using E_Learning_Service.Abstracts;
using MediatR;

namespace E_Learning_Core.Features.Coursess.Commands.Handlers
{
    public class CourseCommandHandler : ResponseHandler,
                                      IRequestHandler<AddCourseCommand, Response<string>>,
                                      IRequestHandler<EditCourseCommand, Response<string>>,
                                      IRequestHandler<DeleteCourseCommand, Response<string>>
    {
        ICourseService courseService;
        IMapper mapper;
        public CourseCommandHandler(ICourseService courseService, IMapper mapper)
        {
            this.courseService = courseService;
            this.mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            var course = mapper.Map<Courses>(request);
            var result = await courseService.AddCourseAsync(course);
            if (result == "Added Successfully")
                return Success("Added successfully");
            else return BadRequest<string>("Added failed");
        }

        public async Task<Response<string>> Handle(EditCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await courseService.GetCourseByIdAsync(request.Id);
            if (course == null) return NotFound<string>();
            var courseMapper = mapper.Map(request, course);
            var result = await courseService.EditCourseAsync(courseMapper);

            if (result == "Success") return Success("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var result = await courseService.DeleteCourseAsync(request.Id);
            if (result == "NotFound")
                return NotFound<string>("course not fount to delete it");
            return Success("Deleted successfully");
        }
    }
}
