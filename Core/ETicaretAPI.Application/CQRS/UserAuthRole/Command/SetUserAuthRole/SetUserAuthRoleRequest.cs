using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.UserAuthRole.Command.SetUserAuthRole
{
    public class SetUserAuthRoleRequest:IRequest<SetUserAuthRoleResponse>
    {
        public string UserId { get; set; }

        public string RoleId { get; set; }
    }
}
