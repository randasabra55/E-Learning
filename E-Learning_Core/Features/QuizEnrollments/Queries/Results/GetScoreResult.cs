namespace E_Learning_Core.Features.QuizEnrollments.Queries.Results
{
    public class GetScoreResult
    {
        public string FullName { get; set; }
        public string Title { get; set; }
        public double Score { get; set; }
        public DateTime AttemptedAt { get; set; }
    }
}
