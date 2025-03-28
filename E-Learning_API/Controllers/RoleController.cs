using E_Learning_API.Bases;
using E_Learning_Core.Features.Roles.Commands.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoleController : AppControllerBase
    {
        [HttpPut("EditRole")]
        public async Task<IActionResult> EditRoleAsync(EditRoleCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        /*[HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRoleAsync(DeleteRoleCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }*/
    }
}
