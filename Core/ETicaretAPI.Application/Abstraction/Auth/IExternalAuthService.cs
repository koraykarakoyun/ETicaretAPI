using ETicaretAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstraction.Auth
{
    public interface IExternalAuthService
    {
        Task<LoginDto> FacbookLogin(string AccessToken, int TokenLifeTime_Seconds);

        Task<LoginDto> GoogleLogin(string IdToken, int TokenLifeTime_Seconds);

    }
}
