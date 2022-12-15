using ETicaretAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstraction.UserAuthRole
{
    public interface IUserAuthRoleService
    {
        Task<bool> SetUserAuthRoleAsync(string UserId, string RoleId);

        Task<GetByIdUserAuthRoleDto> GetByIdUserAuthRoleAsync(string UserId);
    }
}
