using ETicaretAPI.Application.DTOs.CreateUser;
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

    }
}
