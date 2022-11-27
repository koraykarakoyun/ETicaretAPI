using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.AuthorizationEndpoint.Command.AssingRoleEndpoint
{
    public class AssingRoleEndpointCommandRequest : IRequest<AssingRoleEndpointCommandResponse>
    {
        public string menu { get; set; }

        public Type? Type { get; set; }
        public string code { get; set; }

        public string[] roles { get; set; }

    }
}
