

using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Roles.Commands.Models
{
    public class DeleteRoleCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }

}
