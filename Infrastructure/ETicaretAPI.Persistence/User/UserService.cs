using ETicaretAPI.Application.Abstraction.User;
using ETicaretAPI.Application.CQRS.User.Command.CreateUser;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.DTOs.CreateUser;
using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.User
{
    public class UserService : IUserService
    {

        UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task AssignUserRoles(string Id, string[] Roles)
        {
            AppUser appUser = await _userManager.FindByIdAsync(Id);
            if (appUser != null)
            {
                var roles = await _userManager.GetRolesAsync(appUser);
                await _userManager.RemoveFromRolesAsync(appUser, roles);
                await _userManager.AddToRolesAsync(appUser, Roles);
            }


        }

        public async Task<CreateUserResponseDto> CreateUser(CreateUserRequestDto createUserDto)
        {

            IdentityResult ıdentityResult = await _userManager.CreateAsync(new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                Name = createUserDto.Name,
                Surname = createUserDto.Surname,
                UserName = createUserDto.Username,
                Email = createUserDto.Email,

            }, createUserDto.Password);

            CreateUserResponseDto response = new() { IsSuccess = ıdentityResult.Succeeded };

            if (response.IsSuccess)
            {
                response.Message = "Kullanıcı olusturuldu";
            }
            else
            {
                foreach (var error in ıdentityResult.Errors)
                {
                    response.Message += error.Description;
                }
            }
            return response;

        }

        public async Task<List<GetAllUserDto>> GetAllUser()
        {
            var users = await _userManager.Users.ToListAsync();

            return users.Select(a => new GetAllUserDto()
            {
                Id = a.Id,
                Name = a.Name,
                Surname = a.Surname,
                Email = a.Email,
                UserName = a.UserName,
                TwoFactoryEnable = a.TwoFactorEnabled
            }).ToList();

        }

        public async Task<List<string>> GetByIdUserRoles(string Id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(Id);
            if (appUser != null)
            {
                var roles = await _userManager.GetRolesAsync(appUser);
                return roles.ToList();

            }
            return null;

        }

        public async Task UpdateRefreshToken(AppUser appUser, string refreshToken, DateTime accessTokenEndTime, int addOnAccessTokenTime)
        {
            if (appUser != null)
            {
                appUser.RefreshToken = refreshToken;
                appUser.RefreshTokenLifeTime = accessTokenEndTime.AddSeconds(addOnAccessTokenTime);
                await _userManager.UpdateAsync(appUser);
            }
            else
            {
                throw new Exception("Kullanıcı Bulunamadı");
            }

        }
    }
}
