namespace E_Learning_Core.Features.Questions.Queries.Results
{
    public class GetQuestionResult
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<string> Answers { get; set; }
    }
}
