using E_Learning_Data.Entities;

namespace E_Learning_Service.Abstracts
{
    public interface IQuizEnrollmentService
    {
        public Task<string> AddAttempt(UserQuizAttempts userQuizAttempts);
    }
}
