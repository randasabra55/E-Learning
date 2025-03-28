using E_Learning_Data.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Data.Entities
{
    public class Enrollments
    {
        public int Id { get; set; }
        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;



        [ForeignKey("users")]
        public int UserId { get; set; }
        public virtual User users { get; set; }
        [ForeignKey("courses")]
        public int CourseId { get; set; }
        public virtual Courses courses { get; set; }
    }
}
