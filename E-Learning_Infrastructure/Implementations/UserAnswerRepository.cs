using E_Learning_Data.Entities;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Infrastructure.Data;
using E_Learning_Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Infrastructure.Implementations
{
    public class UserAnswerRepository : GenericRepository<UserQuizAnswers>, IUserAnswerRepository
    {
        private DbSet<UserQuizAnswers> answers;
        public UserAnswerRepository(Context dbContext) : base(dbContext)
        {
            answers = dbContext.Set<UserQuizAnswers>();
        }
    }
}
