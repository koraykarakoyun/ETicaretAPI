using ETicaretAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstraction.Role
{
    public interface IRoleService
    {
        //CRUD

        Task<bool> CreateRoleAsync(string name);

        Task<List<GetAllRolesDto>> GetAllRolesAsync();

        Task<(string id,string role)> GetRoleByIdAsync(string id);

        Task<bool> UpdateRoleAsync(string id ,string name);

        Task<bool> DeleteRoleAsync(string id);
    }
}
