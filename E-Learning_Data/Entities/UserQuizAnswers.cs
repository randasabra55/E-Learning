using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Data.Entities
{
    public class UserQuizAnswers
    {
        public int Id { get; set; }


        [ForeignKey("UserQuizAttempt")]
        public int UserQuizAttemptId { get; set; }
        public virtual UserQuizAttempts UserQuizAttempt { get; set; }

        [ForeignKey("QuizQuestion")]
        public int QuestionId { get; set; }
        public virtual QuizQuestions QuizQuestion { get; set; }

        [ForeignKey("QuizAnswer")]
        public int AnswerId { get; set; }
        public virtual QuizAnswers QuizAnswer { get; set; }
    }
}
