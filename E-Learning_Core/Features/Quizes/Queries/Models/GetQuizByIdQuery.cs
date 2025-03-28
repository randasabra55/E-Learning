using E_Learning_Core.Bases;
using E_Learning_Core.Features.Quizes.Queries.Results;
using MediatR;

namespace E_Learning_Core.Features.Quizes.Queries.Models
{
    public class GetQuizByIdQuery : IRequest<Response<GetQuizResult>>
    {
        public int Id { get; set; }
        public GetQuizByIdQuery(int id)
        {
            Id = id;
        }
    }
}
