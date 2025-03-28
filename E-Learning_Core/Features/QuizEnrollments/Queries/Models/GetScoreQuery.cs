using E_Learning_Core.Bases;
using E_Learning_Core.Features.QuizEnrollments.Queries.Results;
using MediatR;

namespace E_Learning_Core.Features.QuizEnrollments.Queries.Models
{
    public class GetScoreQuery : IRequest<Response<GetScoreResult>>
    {
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public GetScoreQuery(int userId, int quizId)
        {
            UserId = userId;
            QuizId = quizId;
        }
    }
}
