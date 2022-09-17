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
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        ITokenHandler _tokenHandler;

        public LoginCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
             AppUser user= await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return new LoginCommandResponse() { Message="Email veya parola hatalı." ,IsSuccess=false};
            }

            SignInResult signInResult= await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (signInResult.Succeeded)
            {
                //kullanıcı login oldu.
               DTOs.Token token= _tokenHandler.CreateAccessToken(5);

                return new LoginCommandResponse() { IsSuccess = true, Message = "Giris yapildi.", Token = token };

            }

            return new();

        }
    }
}
