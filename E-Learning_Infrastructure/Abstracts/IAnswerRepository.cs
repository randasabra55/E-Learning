using E_Learning_Data.Entities;
using E_Learning_Infrastructure.InfrastructureBases;

namespace E_Learning_Infrastructure.Abstracts
{
    public interface IAnswerRepository : IGenericRepository<QuizAnswers>
    {
        public IQueryable<QuizAnswers> GetAnswersQuerable();
    }
}
