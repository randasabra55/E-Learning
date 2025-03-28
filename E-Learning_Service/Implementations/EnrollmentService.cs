using E_Learning_Data.Entities;
using E_Learning_Infrastructure.Data;
using E_Learning_Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Service.Implementations
{
    public class EnrollmentService : IEnrollmentService
    {
        Context context;
        public EnrollmentService(Context context)
        {
            this.context = context;
        }
        public async Task<Enrollments> IsExist(int userId, int courseId)
        {
            return await context.enrollments.FirstOrDefaultAsync(e => e.UserId == userId && e.CourseId == courseId);
        }
        public async Task<string> AddEnrollment(Enrollments enrollment)
        {
            await context.enrollments.AddAsync(enrollment);
            await context.SaveChangesAsync();
            return "Success";
        }
        /* public string courseName(int courseId)
         {
             var enroll = context.enrollments.FirstOrDefault(e => e.courses.Id == courseId);
             var courseName = enroll.courses.Title;
             return courseName;
         }*/
        public async Task<List<string>> GetCoursesEnrolledByUser(int userId)
        {
            var list = await context.enrollments
                              .Where(e => e.UserId == userId)
                              .Include(e => e.courses)
                              .Select(c => c.courses.Title)
                              .ToListAsync();
            return list;
        }
    }
}
