using ETicaretAPI.Application.Abstraction.AuthorizationEndpoint;
using ETicaretAPI.Application.CQRS.AuthorizationEndpoint.Command.AssingRoleEndpoint;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.AuthorizationEndpoint.Command
{
    public class AssignRoleEndpointCommandHandler : IRequestHandler<AssignRoleEndpointCommandRequest, AssignRoleEndpointCommandResponse>
    {
        IAuthorizationEndpointService _authorizationEndpointService;

        public AssignRoleEndpointCommandHandler(IAuthorizationEndpointService authorizationEndpointService)
        {
            _authorizationEndpointService = authorizationEndpointService;
        }


        public async Task<AssignRoleEndpointCommandResponse> Handle(AssignRoleEndpointCommandRequest request, CancellationToken cancellationToken)
        {

            await _authorizationEndpointService.AssignRoleEndpointAsync(request.code, request.roles, request.Type, request.menu);
            return new AssignRoleEndpointCommandResponse();
        }
    }
}
