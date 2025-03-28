using E_Learning_Core.Bases;
using E_Learning_Core.Features.Notificationss.Queries.Results;
using MediatR;

namespace E_Learning_Core.Features.Notificationss.Queries.Models
{
    public class GetNotificationListQuery : IRequest<Response<List<GetNotificationResult>>>
    {
        public int UserId { get; set; }
        public GetNotificationListQuery(int id)
        {
            UserId = id;
        }
    }
}
