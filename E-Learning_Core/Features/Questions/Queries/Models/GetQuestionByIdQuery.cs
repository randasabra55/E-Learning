using E_Learning_Core.Bases;
using E_Learning_Core.Features.Questions.Queries.Results;
using MediatR;

namespace E_Learning_Core.Features.Questions.Queries.Models
{
    public class GetQuestionByIdQuery : IRequest<Response<GetQuestionResult>>
    {
        public int Id { get; set; }
        public GetQuestionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
