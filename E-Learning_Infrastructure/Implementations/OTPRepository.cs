using E_Learning_Data.Entities;
using E_Learning_Data.Entities.Identity;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Infrastructure.Data;
using E_Learning_Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;


namespace E_Learning_Infrastructure.Implementations
{
    public class OTPRepository : GenericRepository<OTP>, IOTPRepository
    {

        private DbSet<OTP> oTPs;
        Context dbContext;

        #region Constructors
        public OTPRepository(Context dbContext) : base(dbContext)
        {
            oTPs = dbContext.Set<OTP>();
            this.dbContext = dbContext;
        }

        public void FindOTPinDatabase(User user)
        {
            var existOTP = oTPs.FirstOrDefault(o => o.UserId == user.Id && !o.IsUsed);
            if (existOTP != null)
            {
                oTPs.Remove(existOTP);
                dbContext.SaveChanges();
            }

            // oTPs.SaveChanges();
            //throw new NotImplementedException();
        }


        #endregion


    }
}
