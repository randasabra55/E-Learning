
using E_Learning_Data.Entities.Identity;
using E_Learning_Data.Results;

namespace E_Learning_Service.Abstracts
{
    public interface IAuthenticationService
    {
        public Task<string> Register(User user, string password);
        public Task<JwtAuthResult> GetJWTToken(User user);
        public Task<string> GenerateOTPCode(string Email);
        public Task<string> VerifyOTPCode(string email, string code);
        public Task<string> ResetPassword(string email, string password);
    }
}
