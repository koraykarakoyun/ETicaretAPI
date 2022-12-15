using ETicaretAPI.Application.Abstraction.UserAuthRole;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Repositories.UserAuthRoles;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.UserAuthRole
{
    public class UserAuthRoleService : IUserAuthRoleService
    {
        UserManager<AppUser> _userManager;
        IUserAuthRolesReadRepository _userAuthRolesReadRepository;
        IUserAuthRolesWriteRepository _userAuthRolesWriteRepository;

        public UserAuthRoleService(UserManager<AppUser> userManager, IUserAuthRolesReadRepository userAuthRolesReadRepository, IUserAuthRolesWriteRepository userAuthRolesWriteRepository)
        {
            _userManager = userManager;
            _userAuthRolesReadRepository = userAuthRolesReadRepository;
            _userAuthRolesWriteRepository = userAuthRolesWriteRepository;
        }

        public async Task<GetByIdUserAuthRoleDto> GetByIdUserAuthRoleAsync(string UserId)
        {
            AppUser appUser = await _userManager.Users.Include(a => a.UserAuthRole).SingleOrDefaultAsync(a => a.Id == UserId);

            if (appUser != null)
            {
                return new()
                {
                    RoleId = appUser.UserAuthRole.Id.ToString(),
                    RoleName = appUser.UserAuthRole.RoleName
                };

            }
            throw new Exception("Kullanıcı Bulunamadı");


        }

        public async Task<bool> SetUserAuthRoleAsync(string UserId, string RoleId)
        {
            AppUser appUser = await _userManager.Users.Include(a => a.UserAuthRole).SingleOrDefaultAsync(a => a.Id == UserId);
            Domain.Entities.UserAuthRole userAuthRole = await _userAuthRolesReadRepository.GetSingleAsync(a => a.Id == Guid.Parse(RoleId));

            if (appUser != null && userAuthRole != null)
            {
                appUser.UserAuthRole = userAuthRole;
                await _userManager.UpdateAsync(appUser);
                return true;
            }
            return false;
        }
    }
}
