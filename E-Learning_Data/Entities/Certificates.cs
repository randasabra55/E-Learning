using E_Learning_Data.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Data.Entities
{
    public class Certificates
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;
        public string CertificateUrl { get; set; }



        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Courses")]
        public int CourseId { get; set; }
        public virtual Courses Courses { get; set; }
    }
}
