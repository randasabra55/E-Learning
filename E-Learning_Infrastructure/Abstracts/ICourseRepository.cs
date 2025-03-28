using E_Learning_Data.Entities;
using E_Learning_Infrastructure.InfrastructureBases;

namespace E_Learning_Infrastructure.Abstracts
{
    public interface ICourseRepository : IGenericRepository<Courses>
    {
        public IQueryable<Courses> GetCoursesListAsync();
        public IQueryable<Courses> GetCoursesListIncludeLessonsAsync();
        public Task<Courses> GetCourseIncludeLessonsAsync(int courseId);

    }
}
