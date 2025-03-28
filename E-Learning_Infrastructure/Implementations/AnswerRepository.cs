using E_Learning_Data.Entities;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Infrastructure.Data;
using E_Learning_Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Infrastructure.Implementations
{
    public class AnswerRepository : GenericRepository<QuizAnswers>, IAnswerRepository
    {
        private DbSet<QuizAnswers> answers;

        public AnswerRepository(Context context) : base(context)
        {
            answers = context.Set<QuizAnswers>();
        }

        public IQueryable<QuizAnswers> GetAnswersQuerable()
        {
            return answers.AsNoTracking().AsQueryable();
        }
    }
}
