using E_Learning_Data.Entities;
using E_Learning_Data.Entities.Identity;
using E_Learning_Data.Helper;
using E_Learning_Data.Results;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Infrastructure.Data;
using E_Learning_Service.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace E_Learning_Service.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        UserManager<User> userManager;
        JwtSettings jwtSettings;
        IOTPRepository otpRepository;
        Context context;
        public AuthenticationService(UserManager<User> userManager, JwtSettings jwtSettings, IOTPRepository otpRepository, Context context)
        {
            this.userManager = userManager;
            this.jwtSettings = jwtSettings;
            this.otpRepository = otpRepository;
            this.context = context;
        }

        public async Task<JwtAuthResult> GetJWTToken(User user)
        {
            //design token
            var accessToken = new JwtSecurityToken(
                issuer: jwtSettings.issuer,
                audience: jwtSettings.audience,
                expires: DateTime.Now.AddDays(jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.secret)), SecurityAlgorithms.HmacSha256Signature),
                claims: await GetClaims(user)
                );
            RefreshToken refreshToken = new RefreshToken()
            {
                UserName = user.UserName,
                ExpireAt = DateTime.Now.AddDays(jwtSettings.RefreshTokenExpireDate),
                Token = GenerateRefreshToken(),
            };
            JwtAuthResult jwtAuthResult = new JwtAuthResult()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                refreshToken = refreshToken
            };
            return jwtAuthResult;

        }

        public async Task<List<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };
            var Rules = await userManager.GetRolesAsync(user);
            foreach (var rule in Rules)
            {
                claims.Add(new Claim(ClaimTypes.Role, rule));
            }

            return claims;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var genrator = RandomNumberGenerator.Create();
            genrator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public async Task<string> Register(User user, string password)
        {

            //chek email exist or not
            var existEmail = await userManager.FindByEmailAsync(user.Email);
            if (existEmail != null)
            {
                return "EmailIsExist";
            }
            //check user name
            var existUserName = await userManager.FindByNameAsync(user.UserName);
            if (existUserName != null)
            {
                return "UserNameIsExist";
            }
            try
            {
                user.Role = "Student";
                var result = await userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    return string.Join(",", result.Errors.Select(x => x.Description).ToList());
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.InnerException?.Message ?? ex.Message}";

            }


            //add him to role
            await userManager.AddToRoleAsync(user, "Student");
            return "Created";

        }

        public async Task<string> GenerateOTPCode(string Email)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.Email == Email);
            if (user == null)
            {
                return "User not found";
            }
            var code = new Random().Next(100000, 999999).ToString();
            //otpRepository.FindOTPinDatabase(user);
            var otpCode = new OTP()
            {
                UserId = user.Id,
                Code = code,
                ExpireAt = DateTime.Now.AddMinutes(5),
                // IsUsed = false
            };
            await otpRepository.AddAsync(otpCode);
            await SendOtpByEmail(Email, code);
            return code;
            //throw new NotImplementedException();
        }

        /*private async Task SendOtpByEmail(string email, string otp)
        {
            var fromAddress = new MailAddress("randasabra27@gmail.com");
            var toAddress = new MailAddress(email);
            const string fromPassword = "gzqz fpnp oixd ljdo";
            const string subject = "Password Reset OTP";
            string body = $"Your OTP Code is: {otp}. It will expire in 5 minutes.";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                await smtp.SendMailAsync(message);
            }
        }*/

        private async Task SendOtpByEmail(string email, string otp)
        {
            try
            {
                var fromAddress = new MailAddress("randasabra27@gmail.com", "Your App Name");
                var toAddress = new MailAddress(email);
                const string fromPassword = "gzqz fpnp oixd ljdo";
                const string subject = "Password Reset OTP";
                string body = $"Your OTP Code is: {otp}. It will expire in 5 minutes.";

                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);

                    using (var message = new MailMessage())
                    {
                        message.From = fromAddress;
                        message.To.Add(toAddress);
                        message.Subject = subject;
                        message.Body = body;
                        message.IsBodyHtml = false;

                        await smtp.SendMailAsync(message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }

        public async Task<string> VerifyOTPCode(string email, string code)
        {
            var user = await userManager.FindByEmailAsync(email);
            var codeFromDatabase = context.OTPs.FirstOrDefault(o => o.UserId == user.Id && !o.IsUsed && o.Code == code);
            if (codeFromDatabase == null)
                return "Invalid OTP or expired";
            else if (codeFromDatabase.ExpireAt < DateTime.UtcNow)
                return "OTP has expired";
            codeFromDatabase.IsUsed = true;
            await context.SaveChangesAsync();

            return "Success";
        }

        public async Task<string> ResetPassword(string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return "UserNotFound";
            await userManager.RemovePasswordAsync(user);
            if (!await userManager.HasPasswordAsync(user))
            {
                await userManager.AddPasswordAsync(user, password);
            }

            return "Success";
        }


    }
}
