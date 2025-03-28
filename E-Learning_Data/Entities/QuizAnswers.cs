using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Data.Entities
{
    public class QuizAnswers
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }




        [ForeignKey("QuizQuestions")]
        public int QuestionId { get; set; }
        public virtual QuizQuestions QuizQuestions { get; set; }

        public virtual ICollection<UserQuizAnswers>? UserQuizAnswers { get; set; }
    }
}
