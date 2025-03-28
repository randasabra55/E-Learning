using AutoMapper;
using E_Learning_Core.Bases;
using E_Learning_Core.Features.QuizEnrollments.Queries.Models;
using E_Learning_Core.Features.QuizEnrollments.Queries.Results;
using E_Learning_Data.Entities;
using E_Learning_Data.Entities.Identity;
using E_Learning_Infrastructure.Data;
using E_Learning_Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Core.Features.QuizEnrollments.Queries.Handlers
{
    public class ScoreQueryHandler : ResponseHandler,
                                  IRequestHandler<GetScoreQuery, Response<GetScoreResult>>
    {
        IQuizUserService quizUserService;
        IMapper mapper;
        UserManager<User> userManager;
        Context context;
        INotificationService notificationService;
        public ScoreQueryHandler(IQuizUserService quizUserService, IMapper mapper, UserManager<User> userManager, Context context, INotificationService notificationService)
        {
            this.quizUserService = quizUserService;
            this.mapper = mapper;
            this.userManager = userManager;
            this.context = context;
            this.notificationService = notificationService;
        }
        public async Task<Response<GetScoreResult>> Handle(GetScoreQuery request, CancellationToken cancellationToken)
        {

            var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);
            if (user == null)
                return BadRequest<GetScoreResult>("User not found");

            var quiz = await context.quizzes.FirstOrDefaultAsync(q => q.Id == request.QuizId);
            if (quiz == null)
                return BadRequest<GetScoreResult>("Quiz not found");

            await quizUserService.GetStudentScoreAsync(request.UserId, request.QuizId);

            var userQuiz = await context.userQuizzes
                .FirstOrDefaultAsync(uq => uq.UserId == request.UserId && uq.QuizId == request.QuizId);

            if (userQuiz == null)
                return BadRequest<GetScoreResult>("No quiz attempt found for this user.");


            var result = mapper.Map<GetScoreResult>(userQuiz);
            var notification = new Notifications
            {
                UserId = request.UserId,
                Message = $"Congratulations! You have scored {userQuiz.Score} in the quiz \"{userQuiz.Quizzes.Title}\".",
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
            return Success(result);

        }
    }
}
