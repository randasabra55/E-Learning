using E_Learning_Data.Entities;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Infrastructure.Data;
using E_Learning_Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Infrastructure.Implementations
{
    public class QuizRepository : GenericRepository<Quizzes>, IQuizRepository
    {
        private DbSet<Quizzes> quizzes;
        public QuizRepository(Context dbContext) : base(dbContext)
        {
            quizzes = dbContext.Set<Quizzes>();
        }

        public IQueryable<Quizzes> GetQuizesQuerableAsync()
        {
            // return quizzes.AsNoTracking().AsQueryable();
            return quizzes.Include(q => q.Questions)
                          .ThenInclude(q => q.Answers)
                          .AsNoTracking()
                          .AsQueryable();
        }
        public async Task<Quizzes> GetQuizByIdIncludeQuestionAsync(int quizId)
        {
            return await quizzes.Include(q => q.Questions)
                                .ThenInclude(q => q.Answers)
                                .FirstOrDefaultAsync(q => q.Id == quizId);
        }
    }
}
