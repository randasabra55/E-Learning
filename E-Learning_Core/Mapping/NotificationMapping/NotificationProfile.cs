using AutoMapper;


namespace E_Learning_Core.Mapping.NotificationMapping
{
    public partial class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            GetNotificationByIdMapping();
            GetNotificationListMapping();
        }
    }
}
