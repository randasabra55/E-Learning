using E_Learning_Data.Entities;
using E_Learning_Data.Entities.Identity;
using E_Learning_Data.Requests;

namespace E_Learning_Service.Abstracts
{
    public interface ICourseService
    {
        public Task<string> AddCourseAsync(Courses course);
        public Task<string> EditCourseAsync(Courses course);
        public Task<string> DeleteCourseAsync(int courseId);
        public IQueryable<Courses> GetCoursesAsync(GetCoursePaginatedRequest request);
        public Task<Courses> GetCourseByIdAsync(int courseId);
        public Task<bool> IsTitleExistExcludeSelf(string title, int courseId);
        public Task<List<int>> GetAllUsersIDInrolledIncourse(int courseId);
        public IQueryable<User> GetAllUsersInrolledInCourse(int courseId);

    }
}
