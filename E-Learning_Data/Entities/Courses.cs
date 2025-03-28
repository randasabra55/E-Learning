using E_Learning_Data.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Data.Entities
{
    public class Courses
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;



        public virtual ICollection<Enrollments>? userEnrollments { get; set; }
        public virtual ICollection<Lessons> lessons { get; set; }
        public virtual ICollection<Reviews>? userReviews { get; set; }
        public virtual ICollection<Quizzes>? quizzes { get; set; }

        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        public virtual User Instructor { get; set; }

        /* [ForeignKey("Certificates")]
         public int CertificateId { get; set; }*/
        public virtual Certificates Certificates { get; set; }
    }
}

