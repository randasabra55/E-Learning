using E_Learning_Data.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Data.Entities
{
    public class Reviews
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Courses")]
        public int CourseId { get; set; }
        public virtual Courses Courses { get; set; }
    }
}
