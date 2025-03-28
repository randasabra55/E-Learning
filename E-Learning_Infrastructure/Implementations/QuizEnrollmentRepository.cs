using E_Learning_Data.Entities;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Infrastructure.Data;
using E_Learning_Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Infrastructure.Implementations
{
    public class QuizEnrollmentRepository : GenericRepository<UserQuizAttempts>, IQuizEnrollmentRepository
    {
        private DbSet<UserQuizAttempts> userQuizAttempts;
        public QuizEnrollmentRepository(Context dbContext) : base(dbContext)
        {
            userQuizAttempts = dbContext.Set<UserQuizAttempts>();
        }
    }
}

