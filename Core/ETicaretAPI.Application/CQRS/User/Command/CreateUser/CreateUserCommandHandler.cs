using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Application.Abstraction.User;
using ETicaretAPI.Application.DTOs.CreateUser;

namespace ETicaretAPI.Application.CQRS.User.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        IUserService _userService;
        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
           CreateUserResponseDto responseDto=await _userService.CreateUser(new CreateUserRequestDto()
            {
                Name = request.Name,
                Surname = request.Surname,
                Username = request.Username,
                PhoneNumber=request.PhoneNumber,
                Email = request.Email,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm
            });

            return new CreateUserCommandResponse()
            {
                IsSuccess = responseDto.IsSuccess,
                Message = responseDto.Message
            };

        }
    }
}
