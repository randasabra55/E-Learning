using E_Learning_Data.Entities;

namespace E_Learning_Service.Abstracts
{
    public interface INotificationService
    {
        public Task<string> AddNotification(Notifications n);
        public Task<Notifications> GetNotificationById(int id);
        public Task<List<Notifications>> GetAllNotificationForUser(int userId);
    }
}
