using E_Learning_Data.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Data.Entities
{
    public class Notifications
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; } = false;


        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
