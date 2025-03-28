

using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Users.Commands.Models
{
    public class ResetPasswordCommand : IRequest<Response<string>>
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
