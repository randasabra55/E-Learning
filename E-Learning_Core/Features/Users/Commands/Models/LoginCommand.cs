using E_Learning_Core.Bases;
using E_Learning_Data.Results;
using MediatR;

namespace E_Learning_Core.Features.Users.Commands.Models
{
    public class LoginCommand : IRequest<Response<JwtAuthResult>>
    //public class LoginCommand : IRequest<Response<string>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
