using ETicaretAPI.Application.Abstraction.UserAuthRole;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Repositories.UserAuthRoles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.UserAuthRole.Query.GetByIdUserAuthRole
{
    public class GetByIdUserAuthRoleHandler : IRequestHandler<GetByIdUserAuthRoleRequest, GetByIdUserAuthRoleResponse>
    {
        IUserAuthRoleService _userAuthRoleService;

        public GetByIdUserAuthRoleHandler(IUserAuthRoleService userAuthRoleService)
        {
            _userAuthRoleService = userAuthRoleService;
        }

        public async Task<GetByIdUserAuthRoleResponse> Handle(GetByIdUserAuthRoleRequest request, CancellationToken cancellationToken)
        {
            GetByIdUserAuthRoleDto getByIdUserAuthRoleDto = await _userAuthRoleService.GetByIdUserAuthRoleAsync(request.UserId);
            return new()
            {
                RoleId = getByIdUserAuthRoleDto.RoleId.ToUpper(),
                RoleName = getByIdUserAuthRoleDto.RoleName
            };

        }
    }
}
