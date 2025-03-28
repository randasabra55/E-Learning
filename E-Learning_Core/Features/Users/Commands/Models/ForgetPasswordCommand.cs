﻿using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Users.Commands.Models
{
    public class ForgetPasswordCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
    }
}
