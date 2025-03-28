using E_Learning_Data.Entities;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Service.Abstracts;

namespace E_Learning_Service.Implementations
{
    public class UserAnswerService : IUserAnswerService
    {
        IUserAnswerRepository userAnswerRepository;
        public UserAnswerService(IUserAnswerRepository userAnswerRepository)
        {
            this.userAnswerRepository = userAnswerRepository;
        }
        public async Task<string> AddUserAnswer(UserQuizAnswers answers)
        {
            await userAnswerRepository.AddAsync(answers);
            return "Success";
        }

        public async Task<string> AddUserAnswersAsync(int attemptId, List<UserQuizAnswers> userAnswers)
        {
            foreach (var answer in userAnswers)
            {
                answer.UserQuizAttemptId = attemptId;
            }

            await userAnswerRepository.AddRangeAsync(userAnswers);
            return "Success";
        }
    }
}
