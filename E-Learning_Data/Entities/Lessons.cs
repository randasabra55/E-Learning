using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Data.Entities
{
    public class Lessons
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string VideoUrl { get; set; }
        public int Order { get; set; }//ترتيب الدرس


        [ForeignKey("courses")]
        public int CourseId { get; set; }
        public virtual Courses courses { get; set; }
    }
}
