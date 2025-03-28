using AutoMapper;
using E_Learning_Core.Bases;
using E_Learning_Core.Features.Lessonss.Commands.Models;
using E_Learning_Data.Entities;
using E_Learning_Service.Abstracts;
using MediatR;

namespace E_Learning_Core.Features.Lessonss.Commands.Handlers
{
    public class LessonCommandHandler : ResponseHandler,
                                      IRequestHandler<AddLessonCommand, Response<string>>,
                                      IRequestHandler<EditLessonCommand, Response<string>>,
                                      IRequestHandler<DeleteLessonCommand, Response<string>>
    {
        ILessonService lessonService;
        ICourseService courseService;
        IMapper mapper;
        INotificationService notificationService;
        public LessonCommandHandler(ILessonService lessonService, IMapper mapper, INotificationService notificationService, ICourseService courseService)
        {
            this.mapper = mapper;
            this.lessonService = lessonService;
            this.notificationService = notificationService;
            this.courseService = courseService;
        }
        public async Task<Response<string>> Handle(AddLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = mapper.Map<Lessons>(request);
            var result = await lessonService.AddLessonAsync(lesson, request.VideoUrl);
            if (result == "Success")
            {
                var enrolledUsers = await courseService.GetAllUsersIDInrolledIncourse(request.CourseId);

                var notifications = enrolledUsers.Select(userId => new Notifications
                {
                    UserId = userId,
                    Message = "A new lesson has been added to the course you are enrolled in.",
                    IsRead = false
                }).ToList();

                try
                {
                    foreach (var notification in notifications)
                    {
                        await notificationService.AddNotification(notification);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding notifications: {ex.Message}");
                }
                return Success("Lesson added successfully");
            }

            return BadRequest<string>("failed, please try again");
        }

        public async Task<Response<string>> Handle(EditLessonCommand request, CancellationToken cancellationToken)
        {
            var lessonFromDb = await lessonService.GetLessonAsync(request.Id);
            if (lessonFromDb == null) return NotFound<string>("this lesson not found");
            //map
            var edittedLesson = mapper.Map(request, lessonFromDb);
            var result = await lessonService.EditLessonAsync(edittedLesson, request.VideoUrl);
            return Success("Lesson updated successfully");

        }

        public async Task<Response<string>> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
        {
            var result = await lessonService.DeleteLessonAsync(request.Id);
            if (result == "NotFound")
                return NotFound<string>("lesson not found to delete");
            else
                return Success("Deleted successfully");
        }
    }
}

