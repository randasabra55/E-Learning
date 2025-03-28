using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Data.Entities
{
    public class Quizzes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;



        [ForeignKey("Courses")]
        public int CourseId { get; set; }
        public virtual Courses Courses { get; set; }
        //  public virtual ICollection<User_Quizzes>? user_Quizzes { get; set; }
        public virtual ICollection<QuizQuestions>? Questions { get; set; }
        public virtual ICollection<UserQuizAttempts>? UserQuizAttempts { get; set; }


    }
}
