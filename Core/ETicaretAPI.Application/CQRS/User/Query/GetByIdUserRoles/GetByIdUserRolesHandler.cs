using ETicaretAPI.Application.Abstraction.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.User.Query.GetUserRoles
{
    public class GetByIdUserRolesHandler : IRequestHandler<GetByIdUserRolesRequest, GetByIdUserRolesResponse>
    {
        readonly IUserService _userService;

        public GetByIdUserRolesHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetByIdUserRolesResponse> Handle(GetByIdUserRolesRequest request, CancellationToken cancellationToken)
        {
            List<string> roles = await _userService.GetUserRoles(request.Id);
            return new()
            {
                Roles = roles
            };
        }
    }
}
