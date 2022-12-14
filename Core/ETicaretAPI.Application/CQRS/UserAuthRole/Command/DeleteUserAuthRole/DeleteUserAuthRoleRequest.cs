using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.AuthUserRole.Command.DeleteAuthUserRole
{
    public class DeleteUserAuthRoleRequest:IRequest<DeleteUserAuthRoleResponse>
    {
        public string RoleName { get; set; }
    }
}
