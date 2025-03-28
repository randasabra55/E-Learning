using E_Learning_Data.Entities;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Infrastructure.Data;
using E_Learning_Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Infrastructure.Implementations
{
    public class LessonRepository : GenericRepository<Lessons>, ILessonRepository
    {
        private DbSet<Lessons> lessons;
        public LessonRepository(Context dbContext) : base(dbContext)
        {
            lessons = dbContext.Set<Lessons>();
        }

        /*public Task AddLesson(Lessons lesson)
        {
            
            //throw new NotImplementedException();
        }*/
    }
}
