using ETicaretAPI.Application.Abstraction.Auth;
using ETicaretAPI.Application.CQRS.User.Command.GoogleLogin;
using ETicaretAPI.Application.CQRS.User.Command.Login;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Token;
using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.User.Command.FacebookLogin
{
    public class FacebookLoginCommandHandler : IRequestHandler<FacebookLoginCommandRequest, FacebookLoginCommandResponse>
    {


        IAuthService _authService;

        public FacebookLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<FacebookLoginCommandResponse> Handle(FacebookLoginCommandRequest request, CancellationToken cancellationToken)
        {
            LoginDto loginDto = await _authService.FacbookLogin(request.AccessToken,300);

            return new FacebookLoginCommandResponse
            {
                IsSuccess = loginDto.IsSuccess,
                Message = loginDto.Message,
                Token = loginDto.Token
            };


        }
    }
}
