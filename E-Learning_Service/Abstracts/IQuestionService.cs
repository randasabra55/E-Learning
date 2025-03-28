using E_Learning_Data.Entities;

namespace E_Learning_Service.Abstracts
{
    public interface IQuestionService
    {
        public Task<string> AddQuestion(QuizQuestions question);
        public Task<string> EditQuestion(QuizQuestions question);
        public Task<string> DeleteQuestion(int questionId);
        public Task<QuizQuestions> GetQuestionById(int questionId);
        public IQueryable<QuizQuestions> GetPaginatedQuestion();
    }
}
