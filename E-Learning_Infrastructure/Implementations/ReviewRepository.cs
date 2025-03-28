using E_Learning_Data.Entities;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Infrastructure.Data;
using E_Learning_Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Infrastructure.Implementations
{
    public class ReviewRepository : GenericRepository<Reviews>, IReviewRepository
    {
        private DbSet<Reviews> reviews;
        public ReviewRepository(Context dbContext) : base(dbContext)
        {
            reviews = dbContext.Set<Reviews>();
        }

        public IQueryable<Reviews> GetReviewsByCourseIdQuerable(int courseId)
        {
            return reviews.AsNoTracking()
                          .Include(r => r.User)
                          .Where(r => r.CourseId == courseId)
                          .AsQueryable();
        }

        public IQueryable<Reviews> GetReviewsQuerable()
        {
            return reviews.AsNoTracking().Include(r => r.User).AsQueryable();
        }
    }
}
