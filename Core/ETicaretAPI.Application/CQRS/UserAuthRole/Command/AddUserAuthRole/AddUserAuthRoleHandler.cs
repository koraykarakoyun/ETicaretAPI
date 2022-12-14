using ETicaretAPI.Application.Repositories.UserAuthRoles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.UserAuthRole.Command.AddUserAuthRole
{
    public class AddUserAuthRoleHandler : IRequestHandler<AddUserAuthRoleRequest, AddUserAuthRoleResponse>
    {
        IUserAuthRolesWriteRepository _userAuthRolesWriteRepository;

        public AddUserAuthRoleHandler(IUserAuthRolesWriteRepository userAuthRolesWriteRepository)
        {
            _userAuthRolesWriteRepository = userAuthRolesWriteRepository;
        }

        public async Task<AddUserAuthRoleResponse> Handle(AddUserAuthRoleRequest request, CancellationToken cancellationToken)
        {
            await _userAuthRolesWriteRepository.AddAsync(new()
            {
                Id = Guid.NewGuid(),
                RoleName = request.RoleName
            });

            await _userAuthRolesWriteRepository.SaveAsync();

            return new()
            {
                Message = "Role Olusturuldu"
            };
        }
    }
}
