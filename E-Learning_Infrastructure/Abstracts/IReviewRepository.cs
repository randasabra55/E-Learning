using E_Learning_Data.Entities;
using E_Learning_Infrastructure.InfrastructureBases;

namespace E_Learning_Infrastructure.Abstracts
{
    public interface IReviewRepository : IGenericRepository<Reviews>
    {
        public IQueryable<Reviews> GetReviewsQuerable();
        public IQueryable<Reviews> GetReviewsByCourseIdQuerable(int courseId);

    }
}
