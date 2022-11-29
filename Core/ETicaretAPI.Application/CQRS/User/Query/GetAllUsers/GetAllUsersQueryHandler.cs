using ETicaretAPI.Application.Abstraction.User;
using ETicaretAPI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.User.Query.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, List<GetAllUsersQueryResponse>>
    {
       readonly IUserService _userService;

        public GetAllUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<GetAllUsersQueryResponse>> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllUserDto> users= await _userService.GetAllUser();

            return users.Select(a => new GetAllUsersQueryResponse()
            {
                Id=a.Id,
                Name=a.Name,
                Surname=a.Surname,
                Email=a.Email,
                UserName=a.UserName,
                TwoFactoryEnable=a.TwoFactoryEnable
            }).ToList();

        }
    }
}
