using ETicaretAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstraction.Auth
{
    public interface IInternalAuthService
    {
        Task<LoginDto> Login(string Email, string Password, int TokenLifeTime_Seconds);

        Task<DTOs.Token> RefreshTokenLogin(string RefreshToken);
    }
}
