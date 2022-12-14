using ETicaretAPI.Application.Repositories.UserAuthRoles;
using ETicaretAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.AuthUserRole.Command.DeleteAuthUserRole
{
    public class DeleteUserAuthRoleHandler : IRequestHandler<DeleteUserAuthRoleRequest, DeleteUserAuthRoleResponse>
    {
        IUserAuthRolesWriteRepository _userAuthRolesWriteRepository;
        IUserAuthRolesReadRepository _userAuthRolesReadRepository;

        public DeleteUserAuthRoleHandler(IUserAuthRolesWriteRepository userAuthRolesWriteRepository, IUserAuthRolesReadRepository userAuthRolesReadRepository)
        {
            _userAuthRolesWriteRepository = userAuthRolesWriteRepository;
            _userAuthRolesReadRepository = userAuthRolesReadRepository;
        }

        public async Task<DeleteUserAuthRoleResponse> Handle(DeleteUserAuthRoleRequest request, CancellationToken cancellationToken)
        {
           Domain.Entities.UserAuthRole userAuthRole = await _userAuthRolesReadRepository.GetSingleAsync(a => a.RoleName == request.RoleName);

            _userAuthRolesWriteRepository.Remove(userAuthRole);

            await _userAuthRolesWriteRepository.SaveAsync();

            return new()
            {
                Message = "Rol Başarıyla Silinmiştir"
            };
        }
    }
}
