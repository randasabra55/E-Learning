using E_Learning_Data.Entities;

namespace E_Learning_Service.Abstracts
{
    public interface IUserAnswerService
    {
        public Task<string> AddUserAnswer(UserQuizAnswers answers);
        public Task<string> AddUserAnswersAsync(int attemptId, List<UserQuizAnswers> userAnswers);

    }
}
