using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.UserAuthRole.Query.GetByIdUserAuthRole
{
    public class GetByIdUserAuthRoleRequest:IRequest<GetByIdUserAuthRoleResponse>
    {
        public string UserId { get; set; }
    }
}
