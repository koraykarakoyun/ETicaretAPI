using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.AuthUserRole.Command.UpdateAuthUserRole
{
    public class UpdateUserAuthRoleRequest:IRequest<UpdateUserAuthRoleResponse>
    {
        public string RoleName { get; set; }
        public string NewRoleName { get; set; }
    }
}
