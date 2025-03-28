using E_Learning_Core.Bases;
using E_Learning_Core.Features.Answers.Queries.Results;
using MediatR;

namespace E_Learning_Core.Features.Answers.Queries.Models
{
    public class GetAnswersPaginatedQuery : IRequest<Response<GetAnswersForQuestionResult>>
    {
        public int QuestionId { get; set; }
        public GetAnswersPaginatedQuery(int id)
        {
            QuestionId = id;
        }
    }
}
