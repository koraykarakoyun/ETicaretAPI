using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.User.Command.AssignUserRoles
{
    public class AssignUserRolesResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
