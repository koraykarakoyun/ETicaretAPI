using ETicaretAPI.Application.Abstraction.AuthorizationEndpoint;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.AuthorizationEndpoint.Command
{
    public class AssingRoleEndpointCommandHandler : IRequestHandler<AssingRoleEndpointCommandRequest, AssingRoleEndpointCommandResponse>
    {
        IAuthorizationEndpointService _authorizationEndpointService;

        public AssingRoleEndpointCommandHandler(IAuthorizationEndpointService authorizationEndpointService)
        {
            _authorizationEndpointService = authorizationEndpointService;
        }

        public async Task<AssingRoleEndpointCommandResponse> Handle(AssingRoleEndpointCommandRequest request, CancellationToken cancellationToken)
        {
        
            await _authorizationEndpointService.AssingRoleEndpointAsync(request.code,request.roles,request.Type,request.menu);
            return new AssingRoleEndpointCommandResponse();
        }
    }
}
