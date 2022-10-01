using ETicaretAPI.Application.Abstraction.Auth;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Token;
using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.User.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {

        IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {

            LoginDto loginDto= await _authService.Login(request.Email, request.Password,10);

            return new LoginCommandResponse
            {
                IsSuccess = loginDto.IsSuccess,
                Message = loginDto.Message,
                Token = loginDto.Token
            };
        }
    }
}
