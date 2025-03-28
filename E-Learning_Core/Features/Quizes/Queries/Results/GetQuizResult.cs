namespace E_Learning_Core.Features.Quizes.Queries.Results
{
    public class GetQuizResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<GetQuestionResult> Questions { get; set; } = new();
    }

    public class GetQuestionResult
    {
        // public int Id { get; set; }
        public string Question { get; set; }
        public List<GetAnswerResult> Answers { get; set; } = new();
    }

    public class GetAnswerResult
    {
        // public int Id { get; set; }
        public string AnswerText { get; set; }
        // public bool IsCorrect { get; set; } // لو كنت بتدعم الإجابة الصحيحة
    }
}
