using AutoMapper;
using E_Learning_Core.Bases;
using E_Learning_Core.Features.Users.Commands.Models;
using E_Learning_Data.Entities.Identity;
using E_Learning_Data.Results;
using E_Learning_Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Core.Features.Users.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
                                    IRequestHandler<AddUserCommand, Response<string>>,
                                    IRequestHandler<LoginCommand, Response<JwtAuthResult>>,
                                    IRequestHandler<ChangePasswordCommand, Response<string>>,
                                    IRequestHandler<ForgetPasswordCommand, Response<string>>,
                                    IRequestHandler<VerifyOTPCodeCommand, Response<string>>,
                                    IRequestHandler<ResetPasswordCommand, Response<string>>,
                                    IRequestHandler<EditUserCommand, Response<string>>,
                                    IRequestHandler<DeleteUserCommand, Response<string>>

    {
        IAuthenticationService authenticationService;
        IMapper mapper;
        UserManager<User> userManager;

        public UserCommandHandler(IAuthenticationService authenticationService, IMapper mapper, UserManager<User> userManager)
        {
            this.authenticationService = authenticationService;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(request);

            var result = await authenticationService.Register(user, request.Password);


            switch (result)
            {
                case "EmailIsExist": return BadRequest<string>("Email is Exist");
                case "UserNameIsExist": return BadRequest<string>("UserName is Exist");
                case "Created": return Success<string>("Registed succefully");
                default: return BadRequest<string>(result);
            }
        }

        public async Task<Response<JwtAuthResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                var userPassword = await userManager.CheckPasswordAsync(user, request.Password);
                if (userPassword)
                {
                    //generate token
                    var result = await authenticationService.GetJWTToken(user);
                    //return Token 
                    return Success(result);

                }
            }
            return BadRequest<JwtAuthResult>("UserName or password wrong");

        }

        public async Task<Response<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) return BadRequest<string>("user not found");
            IdentityResult result = await userManager.ChangePasswordAsync(user, request.OldPass, request.NewPass);
            if (result.Succeeded)
                return Success<string>("Password changed succefully");
            return BadRequest<string>("can not change your password, please try again");
            //throw new NotImplementedException();
        }

        public async Task<Response<string>> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await authenticationService.GenerateOTPCode(request.Email);
            if (result == "User not found") return BadRequest<string>("User not found");
            else
                return Created(result);
            //throw new NotImplementedException();
        }

        public async Task<Response<string>> Handle(VerifyOTPCodeCommand request, CancellationToken cancellationToken)
        {
            var result = await authenticationService.VerifyOTPCode(request.Email, request.Code);
            if (result == "Invalid OTP or expired")
                return BadRequest<string>("Invalid OTP or expired");
            else if (result == "OTP has expired")
                return BadRequest<string>("OTP has expired");
            else
                return Success("OTP verified successfully");
            //throw new NotImplementedException();
        }

        public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await authenticationService.ResetPassword(request.email, request.password);
            if (result == "UserNotFound")
                return BadRequest<string>("User not found");
            return Success("Password has been reset successfully");
            //throw new NotImplementedException();
        }

        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var oldUser = await userManager.FindByIdAsync(request.Id.ToString());
            if (oldUser == null) return NotFound<string>("user not found");

            var newUser = mapper.Map(request, oldUser);

            var userByUserName = await userManager.Users.FirstOrDefaultAsync(x => x.UserName == newUser.UserName && x.Id != newUser.Id);
            if (userByUserName != null) return BadRequest<string>("UserName is exist");
            var userByFullName = await userManager.Users.FirstOrDefaultAsync(x => x.FullName == newUser.FullName && x.Id != newUser.Id);
            if (userByFullName != null) return BadRequest<string>("FullName is exist before");


            var result = await userManager.UpdateAsync(newUser);
            if (!result.Succeeded) return BadRequest<string>("Failed to edit user");

            return Success("User edited successfully");
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await userManager.FindByIdAsync(request.Id.ToString());
                if (user == null) return NotFound<string>("User not found");
                var roles = await userManager.GetRolesAsync(user);
                if (roles.Any())
                {
                    var roleRemovalResult = await userManager.RemoveFromRolesAsync(user, roles);
                    if (!roleRemovalResult.Succeeded)
                    {
                        var errors = string.Join(", ", roleRemovalResult.Errors.Select(e => e.Description));
                        return BadRequest<string>($"Error removing roles: {errors}");
                    }
                }

                var result = await userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return BadRequest<string>($"Unable to delete user: {errors}");
                }

                return Success("User deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest<string>($"Error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
    }
}
