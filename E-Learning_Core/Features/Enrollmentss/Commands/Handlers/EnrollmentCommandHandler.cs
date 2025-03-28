using AutoMapper;
using E_Learning_Core.Bases;
using E_Learning_Core.Features.Enrollmentss.Commands.Models;
using E_Learning_Data.Entities;
using E_Learning_Service.Abstracts;
using MediatR;

namespace E_Learning_Core.Features.Enrollmentss.Commands.Handlers
{
    public class EnrollmentCommandHandler : ResponseHandler,
                                          IRequestHandler<EnrollStudentCommand, Response<string>>
    {
        IMapper mapper;
        IEnrollmentService enrollmentService;
        INotificationService notificationService;
        public EnrollmentCommandHandler(IMapper mapper, IEnrollmentService enrollmentService, INotificationService notificationService)
        {
            this.mapper = mapper;
            this.enrollmentService = enrollmentService;
            this.notificationService = notificationService;
        }
        public async Task<Response<string>> Handle(EnrollStudentCommand request, CancellationToken cancellationToken)
        {
            var existEnrollment = await enrollmentService.IsExist(request.UserId, request.CourseId);
            if (existEnrollment != null) return BadRequest<string>("Student is already enrolled in this course");
            var enroll = new Enrollments()
            {
                CourseId = request.CourseId,
                UserId = request.UserId,
            };
            await enrollmentService.AddEnrollment(enroll);

            var notification = new Notifications
            {
                UserId = request.UserId,
                Message = $"You have been enrolled in the course",
                IsRead = false
            };
            try
            {
                await notificationService.AddNotification(notification);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding notification: {ex.Message}");
            }
            //await notificationService.AddNotification(notification);
            return Success("Enrollment successful");
        }
    }
}
