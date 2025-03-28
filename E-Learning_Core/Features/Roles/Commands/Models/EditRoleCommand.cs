using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Roles.Commands.Models
{
    public class EditRoleCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
