using ETicaretAPI.Application.Abstraction.Role;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Role
{
    public class RoleService : IRoleService
    {

        readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> CreateRoleAsync(string name)
        {
            IdentityResult ıdentityResult = await _roleManager.CreateAsync(new() { Id = Guid.NewGuid().ToString(), Name = name });
            return ıdentityResult.Succeeded;
        }

        public async Task<bool> DeleteRoleAsync(string id)
        {
            AppRole appRole = await _roleManager.FindByIdAsync(id);
            IdentityResult ıdentityResult = await _roleManager.DeleteAsync(appRole);
            return ıdentityResult.Succeeded;

        }

        public async Task<List<GetAllRolesDto>> GetAllRolesAsync()
        {

            return _roleManager.Roles.Select(a => new GetAllRolesDto() { Id = a.Id, Name = a.Name }).ToListAsync().Result;



        }

        public async Task<(string id, string role)> GetRoleByIdAsync(string id)
        {
            AppRole appRole = await _roleManager.FindByIdAsync(id);
            string role = await _roleManager.GetRoleNameAsync(appRole);
            return (id, role);
        }

        public async Task<bool> UpdateRoleAsync(string id, string name)
        {
            AppRole appRole = await _roleManager.FindByIdAsync(id);
            appRole.Name = name;
            IdentityResult ıdentityResult = await _roleManager.UpdateAsync(appRole);
            return ıdentityResult.Succeeded;
        }
    }
}
