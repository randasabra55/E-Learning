using E_Learning_Data.Entities;
using E_Learning_Data.Entities.Identity;
using E_Learning_Data.Requests;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Infrastructure.Data;
using E_Learning_Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Service.Implementations
{
    public class CourseService : ICourseService
    {
        ICourseRepository courseRepository;
        Context context;
        public CourseService(ICourseRepository courseRepository, Context context)
        {
            this.courseRepository = courseRepository;
            this.context = context;
        }

        public async Task<string> AddCourseAsync(Courses course)
        {
            await courseRepository.AddAsync(course);
            return "Added Successfully";
        }

        public async Task<string> DeleteCourseAsync(int courseId)
        {
            var course = await courseRepository.GetByIdAsync(courseId);
            if (course == null) return "NotFound";
            await courseRepository.DeleteAsync(course);
            return "Deleted successfully";
        }

        public async Task<string> EditCourseAsync(Courses course)
        {
            await courseRepository.UpdateAsync(course);
            return "Success";
        }

        public async Task<Courses> GetCourseByIdAsync(int courseId)
        {
            //return await courseRepository.GetByIdAsync(courseId);
            return await courseRepository.GetCourseIncludeLessonsAsync(courseId);
        }

        public IQueryable<Courses> GetCoursesAsync(GetCoursePaginatedRequest request)
        {
            //return courseRepository.GetCoursesListIncludeLessonsAsync();
            var query = courseRepository.GetCoursesListIncludeLessonsAsync();

            if (!string.IsNullOrEmpty(request.CourseName))
            {
                query = query.Where(c => c.Title.Contains(request.CourseName));
            }

            if (!string.IsNullOrEmpty(request.InstructorName))
            {
                query = query.Where(c => c.Instructor.FullName.Contains(request.InstructorName));
            }

            if (!string.IsNullOrEmpty(request.Description))
            {
                query = query.Where(c => c.Description.Contains(request.Description));
            }

            if (request.Date.HasValue)
            {
                query = query.Where(c => c.CreatedAt.Date == request.Date.Value.Date);
            }

            return query;
        }

        public async Task<bool> IsTitleExistExcludeSelf(string title, int courseId)
        {
            var student = await courseRepository.GetTableNoTracking().Where(x => x.Title.Equals(title) & !x.Id.Equals(courseId)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<List<int>> GetAllUsersIDInrolledIncourse(int courseId)
        {
            var enrolledUsers = await context.enrollments
            .Where(e => e.CourseId == courseId)
            .Select(e => e.UserId)
            .ToListAsync();
            return enrolledUsers;
        }

        public IQueryable<User> GetAllUsersInrolledInCourse(int courseId)
        {
            return context.enrollments
                .Where(e => e.CourseId == courseId)
                .Select(e => e.users)
                .AsQueryable();
        }
    }
}
