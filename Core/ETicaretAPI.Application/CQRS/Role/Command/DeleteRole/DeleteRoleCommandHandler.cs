using ETicaretAPI.Application.Abstraction.Role;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Role.Command.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, DeleteRoleCommandResponse>
    {
        readonly IRoleService _roleService;

        public DeleteRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _roleService.DeleteRoleAsync(request.Id);

            return new DeleteRoleCommandResponse()
            {
                IsSuccess = result,
                Message = "Rol Silinmiştir"
            };
        }
    }
}
