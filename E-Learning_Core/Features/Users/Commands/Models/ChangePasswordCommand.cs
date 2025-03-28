using E_Learning_Core.Bases;
using MediatR;


namespace E_Learning_Core.Features.Users.Commands.Models
{
    public class ChangePasswordCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string OldPass { get; set; }
        public string NewPass { get; set; }
    }
}
