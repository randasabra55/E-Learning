using E_Learning_Data.Entities;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Service.Abstracts;

namespace E_Learning_Service.Implementations
{
    public class QuizEnrollmentService : IQuizEnrollmentService
    {
        IQuizEnrollmentRepository quizEnrollmentRepository;
        public QuizEnrollmentService(IQuizEnrollmentRepository quizEnrollmentRepository)
        {
            this.quizEnrollmentRepository = quizEnrollmentRepository;
        }

        public async Task<string> AddAttempt(UserQuizAttempts userQuizAttempts)
        {
            await quizEnrollmentRepository.AddAsync(userQuizAttempts);
            return "Success";
        }
    }
}
