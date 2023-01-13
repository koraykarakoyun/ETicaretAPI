using ETicaretAPI.Application.Abstraction.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.User.Command.AssignUserRoles
{
    public class AssignUserRolesHandler : IRequestHandler<AssignUserRolesRequest, AssignUserRolesResponse>
    {
         readonly IUserService _userService;

        public AssignUserRolesHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<AssignUserRolesResponse> Handle(AssignUserRolesRequest request, CancellationToken cancellationToken)
        {
            await _userService.AssignUserRoles(request.Id, request.Roles);
            return new AssignUserRolesResponse()
            {
                IsSuccess=true,
                Message="Kullanıcıya Rol Atandı"
            };
        }
    }
}
