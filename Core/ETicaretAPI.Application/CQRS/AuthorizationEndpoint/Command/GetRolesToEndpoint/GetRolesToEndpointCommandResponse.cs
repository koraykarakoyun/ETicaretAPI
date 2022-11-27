using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.AuthorizationEndpoint.Command.GetRolesToEndpoint
{
    public class GetRolesToEndpointCommandResponse
    {
        public List<string> Datas { get; set; }
    }
}
