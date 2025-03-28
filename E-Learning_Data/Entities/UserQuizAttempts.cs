using E_Learning_Data.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Data.Entities
{
    public class UserQuizAttempts
    {
        public int Id { get; set; }
        public DateTime AttemptedAt { get; set; } = DateTime.Now;




        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int QuizId { get; set; }
        [ForeignKey("QuizId")]
        public virtual Quizzes Quiz { get; set; }

        public virtual ICollection<UserQuizAnswers>? userQuizAnswers { get; set; }
    }
}
