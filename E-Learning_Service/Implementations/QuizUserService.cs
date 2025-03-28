using E_Learning_Data.Entities;
using E_Learning_Data.Entities.Identity;
using E_Learning_Infrastructure.Data;
using E_Learning_Service.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Service.Implementations
{
    public class QuizUserService : IQuizUserService
    {
        Context context;
        UserManager<User> userManager;
        public QuizUserService(Context context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }


        public async Task<int> GetStudentScoreAsync(int userId, int quizId)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null) return 0;

            var quiz = await context.quizzes.FirstOrDefaultAsync(q => q.Id == quizId);
            if (quiz == null) return 0;

            var userAnswers = await context.userQuizAnswers
                .Where(ua => ua.UserQuizAttempt.UserId == userId && ua.UserQuizAttempt.QuizId == quizId)
                .ToListAsync();

            if (!userAnswers.Any()) return 0;

            int correctAnswers = await context.quizAnswers
                .Where(q => userAnswers.Select(ua => ua.AnswerId).Contains(q.Id) && q.IsCorrect)
                .CountAsync();

            var userQuiz = await context.userQuizzes
                .FirstOrDefaultAsync(uq => uq.UserId == userId && uq.QuizId == quizId);

            if (userQuiz == null)
            {
                userQuiz = new UserQuizzes
                {
                    UserId = userId,
                    QuizId = quizId,
                    Score = correctAnswers,
                    AttemptedAt = DateTime.UtcNow
                };
                await context.userQuizzes.AddAsync(userQuiz);
            }
            else
            {
                userQuiz.Score = correctAnswers;
                userQuiz.AttemptedAt = DateTime.UtcNow;
            }

            await context.SaveChangesAsync();
            return correctAnswers;
        }

    }
}
