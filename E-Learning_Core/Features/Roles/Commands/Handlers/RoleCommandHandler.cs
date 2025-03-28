using E_Learning_Core.Bases;
using E_Learning_Core.Features.Roles.Commands.Models;
using E_Learning_Service.Abstracts;
using MediatR;

namespace E_Learning_Core.Features.Roles.Commands.Handlers
{
    public class RoleCommandHandler : ResponseHandler,
                                    IRequestHandler<EditRoleCommand, Response<string>>,
                                    IRequestHandler<DeleteRoleCommand, Response<string>>
    {
        IRoleService roleService;
        public RoleCommandHandler(IRoleService roleService)
        {
            this.roleService = roleService;
        }
        public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await roleService.EditRole(request.Id, request.RoleName);
            if (result == $"this user with id {request.Id} not fount")
                return NotFound<string>($"this user with id {request.Id} not fount");
            else if (result == "Failed to assign this role to this user")
                return BadRequest<string>("Failed to assign this role to this user");
            else
                return Success("Assigning role to user is successfully");
            //throw new NotImplementedException();
        }

        public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await roleService.DeleteRole(request.Id);
            if (result == $"this user with id {request.Id} not fount")
                return NotFound<string>($"this user with id {request.Id} not fount");
            else if (result == "Failed to delete this role")
                return BadRequest<string>("Failed to delete this role");
            else
                return Success("Role deleted successfully");
        }
    }
}
