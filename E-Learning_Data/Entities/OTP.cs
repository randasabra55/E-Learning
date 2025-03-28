using E_Learning_Data.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_Data.Entities
{
    public class OTP
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime ExpireAt { get; set; }
        public bool IsUsed { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
