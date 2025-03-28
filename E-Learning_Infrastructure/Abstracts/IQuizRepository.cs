using E_Learning_Data.Entities;
using E_Learning_Infrastructure.InfrastructureBases;

namespace E_Learning_Infrastructure.Abstracts
{
    public interface IQuizRepository : IGenericRepository<Quizzes>
    {
        public IQueryable<Quizzes> GetQuizesQuerableAsync();
        public Task<Quizzes> GetQuizByIdIncludeQuestionAsync(int quizId);


    }
}
