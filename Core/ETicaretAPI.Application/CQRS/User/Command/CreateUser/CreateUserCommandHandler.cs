using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Exceptions;

namespace ETicaretAPI.Application.CQRS.User.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {

        UserManager<AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {



           IdentityResult ıdentityResult= await _userManager.CreateAsync(new AppUser()
            {
                Name = request.Name,
                Surname = request.Surname,
                UserName = request.Username,
                Email = request.Email,

            }, request.Password);

            CreateUserCommandResponse response = new() { IsSuccess = ıdentityResult.Succeeded };

            if (response.IsSuccess)
            {
                response.Message = "Kullanıcı olusturuldu";
            }
            else
            {
                foreach (var error in ıdentityResult.Errors)
                {
                    response.Message += error.Description;
                }
            }
            return response;

        }
    }
}
