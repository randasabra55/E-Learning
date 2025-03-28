using E_Learning_Data.Entities;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Infrastructure.Data;
using E_Learning_Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Infrastructure.Implementations
{
    public class CourseRepository : GenericRepository<Courses>, ICourseRepository
    {
        private DbSet<Courses> courses;

        public CourseRepository(Context context) : base(context)
        {
            courses = context.Set<Courses>();
        }

        public async Task<Courses> GetCourseIncludeLessonsAsync(int courseId)
        {
            return await courses.Include(c => c.lessons).FirstOrDefaultAsync(c => c.Id == courseId);
        }

        public IQueryable<Courses> GetCoursesListAsync()
        {
            return courses.AsNoTracking().AsQueryable();
        }

        public IQueryable<Courses> GetCoursesListIncludeLessonsAsync()
        {
            return courses.AsNoTracking().Include(c => c.lessons).AsQueryable();
        }
    }
}
