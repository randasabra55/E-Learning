using E_Learning_Core.Bases;
using E_Learning_Core.Features.Notificationss.Queries.Results;
using MediatR;

namespace E_Learning_Core.Features.Notificationss.Queries.Models
{
    public class GetNotificationByIdQuery : IRequest<Response<GetNotificationResult>>
    {
        public int Id { get; set; }
        public GetNotificationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
