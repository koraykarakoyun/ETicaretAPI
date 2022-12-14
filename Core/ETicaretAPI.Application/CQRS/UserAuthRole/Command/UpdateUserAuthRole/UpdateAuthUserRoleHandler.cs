using ETicaretAPI.Application.Repositories.UserAuthRoles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.AuthUserRole.Command.UpdateAuthUserRole
{
    public class UpdateAuthUserRoleHandler : IRequestHandler<UpdateUserAuthRoleRequest, UpdateUserAuthRoleResponse>
    {
        IUserAuthRolesWriteRepository _userAuthRolesWriteRepository;
        IUserAuthRolesReadRepository _userAuthRolesReadRepository;

        public UpdateAuthUserRoleHandler(IUserAuthRolesWriteRepository userAuthRolesWriteRepository, IUserAuthRolesReadRepository userAuthRolesReadRepository)
        {
            _userAuthRolesWriteRepository = userAuthRolesWriteRepository;
            _userAuthRolesReadRepository = userAuthRolesReadRepository;
        }

        public async Task<UpdateUserAuthRoleResponse> Handle(UpdateUserAuthRoleRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.UserAuthRole userAuthRole = await _userAuthRolesReadRepository.GetSingleAsync(a => a.RoleName == request.RoleName);
            userAuthRole.RoleName = request.NewRoleName;
            await _userAuthRolesWriteRepository.SaveAsync();
            return new()
            {
                Message = "Rol Güncellenmiştir"
            };
        }
    }
}
