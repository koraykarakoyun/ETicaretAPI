using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.User.Query.GetUserRoles
{
    public class GetByIdUserRolesResponse
    {
        public List<string> Roles { get; set; }
    }
}
