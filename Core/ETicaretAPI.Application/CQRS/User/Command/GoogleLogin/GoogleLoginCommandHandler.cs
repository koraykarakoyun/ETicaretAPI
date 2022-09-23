using ETicaretAPI.Application.Abstraction.Auth;
using ETicaretAPI.Application.CQRS.User.Command.Login;
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

namespace ETicaretAPI.Application.CQRS.User.Command.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        IAuthService _authService;

        public GoogleLoginCommandHandler(IAuthService authService)
        {
 
            _authService = authService;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {

            LoginDto loginDto = await _authService.GoogleLogin(request.IdToken,15);

            return new GoogleLoginCommandResponse
            {
                IsSuccess = loginDto.IsSuccess,
                Message = loginDto.Message,
                Token = loginDto.Token
            };

        }
    }
}
