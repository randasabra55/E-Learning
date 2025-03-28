using E_Learning_Data.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Data.Entities
{
    public class UserQuizzes
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime AttemptedAt { get; set; }



        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Quizzes")]
        public int QuizId { get; set; }
        public virtual Quizzes Quizzes { get; set; }


    }
}
