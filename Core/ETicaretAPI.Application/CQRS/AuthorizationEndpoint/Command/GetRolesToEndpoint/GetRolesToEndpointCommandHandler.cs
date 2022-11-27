using ETicaretAPI.Application.Abstraction.AuthorizationEndpoint;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.AuthorizationEndpoint.Command.GetRolesToEndpoint
{
    public class GetRolesToEndpointCommandHandler : IRequestHandler<GetRolesToEndpointCommandRequest, GetRolesToEndpointCommandResponse>
    {
        IAuthorizationEndpointService _authorizationEndpointService;

        public GetRolesToEndpointCommandHandler(IAuthorizationEndpointService authorizationEndpointService)
        {
            _authorizationEndpointService = authorizationEndpointService;
        }

        public async Task<GetRolesToEndpointCommandResponse> Handle(GetRolesToEndpointCommandRequest request, CancellationToken cancellationToken)
        {

            List<string> roles = await _authorizationEndpointService.GetRolesToEndpoint(request.Menu, request.Code);


            return new GetRolesToEndpointCommandResponse()
            {
                Datas = roles
            };
        }
    }
}
