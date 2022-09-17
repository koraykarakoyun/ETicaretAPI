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

        public LoginCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
               
            }

            return new();

        }
    }
}
