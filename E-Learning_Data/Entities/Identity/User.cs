using Microsoft.AspNetCore.Identity;

namespace E_Learning_Data.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Role { get; set; }
        public string? Bio { get; set; }
        public int YearExperiences { get; set; }
        public string? Specialization { get; set; }
        //public string? ProfileImage { get; set; }


        public virtual ICollection<Enrollments>? userEnrollments { get; set; }
        public virtual ICollection<Reviews>? userReviews { get; set; }
        public virtual ICollection<Notifications>? userNotifications { get; set; }
        public virtual ICollection<UserQuizzes>? userQuizzes { get; set; }
        public virtual ICollection<Certificates>? certificates { get; set; }
        public virtual ICollection<Courses>? courses { get; set; }
        public virtual ICollection<OTP>? OtpCodes { get; set; }
        public virtual ICollection<UserQuizAttempts>? UserQuizAttempts { get; set; }


    }
}
