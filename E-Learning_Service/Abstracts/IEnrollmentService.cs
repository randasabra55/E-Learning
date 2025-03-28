using E_Learning_Data.Entities;

namespace E_Learning_Service.Abstracts
{
    public interface IEnrollmentService
    {
        public Task<Enrollments> IsExist(int userId, int courseId);
        public Task<string> AddEnrollment(Enrollments enrollment);
        public Task<List<string>> GetCoursesEnrolledByUser(int userId);
        /* public string courseName(int courseId);*/
    }
}
