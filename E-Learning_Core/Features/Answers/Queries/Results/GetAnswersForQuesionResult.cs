namespace E_Learning_Core.Features.Answers.Queries.Results
{
    public class GetAnswersForQuestionResult
    {
        public string Question { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
    public class AnswerDto
    {
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }

    }
}
