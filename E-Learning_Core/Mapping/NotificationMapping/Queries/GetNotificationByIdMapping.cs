using E_Learning_Core.Features.Notificationss.Queries.Results;
using E_Learning_Data.Entities;

namespace E_Learning_Core.Mapping.NotificationMapping
{
    public partial class NotificationProfile
    {
        public void GetNotificationByIdMapping()
        {
            CreateMap<Notifications, GetNotificationResult>();
        }
    }
}
