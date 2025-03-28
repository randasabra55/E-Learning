using E_Learning_Data.Entities;
using E_Learning_Data.Entities.Identity;
using E_Learning_Infrastructure.InfrastructureBases;

namespace E_Learning_Infrastructure.Abstracts
{
    public interface IOTPRepository : IGenericRepository<OTP>
    {
        public void FindOTPinDatabase(User user);

    }
}
