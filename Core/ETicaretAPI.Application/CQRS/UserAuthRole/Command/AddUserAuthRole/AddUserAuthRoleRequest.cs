using ETicaretAPI.Application.Repositories.UserAuthRoles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.UserAuthRole.Command.AddUserAuthRole
{
    public class AddUserAuthRoleRequest:IRequest<AddUserAuthRoleResponse>
    {
        public string RoleName { get; set; }
    }
}
