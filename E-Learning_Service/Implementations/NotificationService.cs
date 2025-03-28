using E_Learning_Data.Entities;
using E_Learning_Infrastructure.Data;
using E_Learning_Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Service.Implementations
{
    public class NotificationService : INotificationService
    {
        Context context;
        public NotificationService(Context context)
        {
            this.context = context;
        }
        public async Task<string> AddNotification(Notifications n)
        {
            await context.notifications.AddAsync(n);
            await context.SaveChangesAsync();
            return "Success";
        }

        public async Task<Notifications> GetNotificationById(int id)
        {
            var notify = await context.notifications.FirstOrDefaultAsync(n => n.Id == id);
            notify.IsRead = true;
            context.notifications.Update(notify);
            context.SaveChanges();
            return notify;
        }
        public async Task<List<Notifications>> GetAllNotificationForUser(int userId)
        {
            return await context.notifications.Where(n => n.UserId == userId).ToListAsync();

        }
    }
}
