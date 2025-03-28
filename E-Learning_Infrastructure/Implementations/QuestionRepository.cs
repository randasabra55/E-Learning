using E_Learning_Data.Entities;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Infrastructure.Data;
using E_Learning_Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Infrastructure.Implementations
{
    class QuestionRepository : GenericRepository<QuizQuestions>, IQuestionRepository
    {
        private DbSet<QuizQuestions> questions;

        public QuestionRepository(Context dbContext) : base(dbContext)
        {
            questions = dbContext.Set<QuizQuestions>();
        }

        public IQueryable<QuizQuestions> GetQuestionQuerableAsync()
        {
            //return questions.AsNoTracking().AsQueryable();
            return questions.Include(q => q.Answers).AsNoTracking().AsQueryable();
        }

        public async Task<QuizQuestions> GetQuestionIncludingAnswersById(int questionId)
        {
            return await questions.Include(q => q.Answers).FirstOrDefaultAsync(q => q.Id == questionId);
        }

        /*public Task<QuizQuestions> GetQuestionIncludingAnswersById(int questionId)
        {
            throw new NotImplementedException();
        }*/
    }
}
