using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstraction.AuthorizationEndpoint
{
    public interface IAuthorizationEndpointService
    {
        Task AssingRoleEndpointAsync(string Code, string[] Roles,Type type,string Menu);

        Task<List<string>> GetRolesToEndpoint(string Menu,string Code);
    }
}
