using ETicaretAPI.Application.Repositories.UserAuthRoles;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.UserAuthRole.Query.GetAllUserAuthRole
{
    public class GetAllUserAuthRoleHandler : IRequestHandler<GetAllUserAuthRoleRequest, List<GetAllUserAuthRoleResponse>>
    {
        IUserAuthRolesReadRepository _userAuthRolesReadRepository;

        public GetAllUserAuthRoleHandler(IUserAuthRolesReadRepository userAuthRolesReadRepository)
        {
            _userAuthRolesReadRepository = userAuthRolesReadRepository;
        }

        public async Task<List<GetAllUserAuthRoleResponse>> Handle(GetAllUserAuthRoleRequest request, CancellationToken cancellationToken)
        {
            return await _userAuthRolesReadRepository.GetAll().Select(a => new GetAllUserAuthRoleResponse()
            {
                RoleId = a.Id.ToString(),
                RoleName = a.RoleName
            }).ToListAsync();
        }
    }
}
