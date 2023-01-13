using ETicaretAPI.Application.Abstraction.Role;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Role.Command.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, UpdateRoleCommandResponse>
    {
        readonly IRoleService _roleService;

        public UpdateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _roleService.UpdateRoleAsync(request.Id,request.Name);
            return new UpdateRoleCommandResponse()
            {
                IsSuccess = result,
                Message = "Rol Güncellenmiştir"
            };
        }
    }
}
