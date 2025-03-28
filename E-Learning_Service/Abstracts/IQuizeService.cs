using E_Learning_Data.Entities;

namespace E_Learning_Service.Abstracts
{
    public interface IQuizeService
    {
        public Task<string> AddQuiz(Quizzes quiz);
        public Task<string> EditQuiz(Quizzes quiz);
        public Task<Quizzes> GetQuizById(int quizId);
        public Task<string> DeleteQuiz(int quizId);
        public IQueryable<Quizzes> GetQuizzessAsync();

    }
}
