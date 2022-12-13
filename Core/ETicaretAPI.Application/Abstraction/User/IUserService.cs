using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.DTOs.CreateUser;
using ETicaretAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstraction.User
{
    public interface IUserService
    {

        Task<CreateUserResponseDto> CreateUser(CreateUserRequestDto createUserDto);

        Task UpdateRefreshToken(AppUser appUser,string refreshToken,DateTime accessTokenEndTime,int addOnAccessTokenTime);

        Task<List<GetAllUserDto>> GetAllUser();

        Task AssignUserRoles(string Id,string[] Roles);

        Task<List<string>> GetUserRoles(string IdOrUserName);


        Task<bool> HasRolePermissionToEndpointAsync(string username,string code);

        Task<bool> IsAdminAsync(string userName);



    }
}
