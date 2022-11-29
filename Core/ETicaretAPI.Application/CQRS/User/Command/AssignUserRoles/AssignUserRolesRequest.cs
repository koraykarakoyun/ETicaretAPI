using ETicaretAPI.Application.CQRS.AuthorizationEndpoint.Command.AssingRoleEndpoint;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.User.Command.AssignUserRoles
{
    public class AssignUserRolesRequest:IRequest<AssignUserRolesResponse>
    {
        public string Id { get; set; }

        public string[] Roles { get; set; }
    }
}
