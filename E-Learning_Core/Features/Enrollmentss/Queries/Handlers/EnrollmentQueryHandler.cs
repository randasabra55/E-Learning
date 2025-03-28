using AutoMapper;
using E_Learning_Core.Bases;
using E_Learning_Core.Features.Enrollmentss.Queries.Models;
using E_Learning_Core.Features.Enrollmentss.Queries.Results;
using E_Learning_Service.Abstracts;
using MediatR;

namespace E_Learning_Core.Features.Enrollmentss.Queries.Handlers
{
    public class EnrollmentQueryHandler : ResponseHandler,
                                         IRequestHandler<GetCoursesEnrolledByUserQuery, Response<List<GetCoursesEnrolledByUserResult>>>
    {
        IMapper mapper;
        IEnrollmentService enrollmentService;
        public EnrollmentQueryHandler(IMapper mapper, IEnrollmentService enrollmentService)
        {
            this.mapper = mapper;
            this.enrollmentService = enrollmentService;
        }

        public async Task<Response<List<GetCoursesEnrolledByUserResult>>> Handle(GetCoursesEnrolledByUserQuery request, CancellationToken cancellationToken)
        {
            var list = await enrollmentService.GetCoursesEnrolledByUser(request.UserId);
            var result = mapper.Map<List<GetCoursesEnrolledByUserResult>>(list);
            return Success(result);
        }
    }
}
