using ETicaretAPI.Application.CQRS.Role.Query.GetRoleById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.AuthorizationEndpoint.Command.GetRolesToEndpoint
{
    public class GetRolesToEndpointCommandRequest:IRequest<GetRolesToEndpointCommandResponse>
    {
        public string Menu { get; set; }

        public string Code { get; set; }
    }
}
