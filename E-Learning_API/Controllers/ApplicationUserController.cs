using E_Learning_API.Bases;
using E_Learning_Core.Features.Users.Commands.Models;
using E_Learning_Core.Features.Users.Queries.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {
        /*public IMediator mediator;
        public ApplicationUserController(IMediator mediator)
        {
            this.mediator = mediator;
        }*/
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(AddUserCommand addUser)
        {
            /*var result = await mediator.Send(addUser);
            return Ok(result);*/
            var result = await Mediator.Send(addUser);
            return NewResult(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPasswordAsync(ForgetPasswordCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpPost("VerifyOTP")]
        public async Task<IActionResult> VerifyOTPCodeAsync(VerifyOTPCodeCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [Authorize]
        [HttpPut("EditProfile")]
        public async Task<IActionResult> EditUserAsync(EditUserCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteUser/{id:int}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] int id)
        {
            var result = await Mediator.Send(new DeleteUserCommand(id));
            return NewResult(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetUserById/{id:int}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] int id)
        {
            var result = await Mediator.Send(new GetUserByIdQuery(id));
            return NewResult(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Paginated")]
        public async Task<IActionResult> GetUserPaginatedListAsync([FromQuery] GetUserPaginatedQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
