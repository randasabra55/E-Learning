using E_Learning_Data.Entities;
using E_Learning_Infrastructure.InfrastructureBases;

namespace E_Learning_Infrastructure.Abstracts
{
    public interface IQuestionRepository : IGenericRepository<QuizQuestions>
    {
        public IQueryable<QuizQuestions> GetQuestionQuerableAsync();
        public Task<QuizQuestions> GetQuestionIncludingAnswersById(int questionId);
    }
}
