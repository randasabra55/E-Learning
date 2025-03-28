using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Data.Entities
{
    public class QuizQuestions
    {
        public int Id { get; set; }
        public string Question { get; set; }
        // public Enum Type { get; set; }



        [ForeignKey("Quizzes")]
        public int QuizId { get; set; }
        public virtual Quizzes Quizzes { get; set; }

        public virtual ICollection<QuizAnswers> Answers { get; set; }
        public virtual ICollection<UserQuizAnswers>? UserQuizAnswers { get; set; }
    }
}
