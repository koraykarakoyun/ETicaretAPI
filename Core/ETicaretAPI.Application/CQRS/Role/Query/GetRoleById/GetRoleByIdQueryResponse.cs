using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Role.Query.GetRoleById
{
    public class GetRoleByIdQueryResponse
    {
        public string Id { get; set; }
        public string Role { get; set; }
    }
}
