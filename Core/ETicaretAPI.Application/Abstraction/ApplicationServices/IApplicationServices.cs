using ETicaretAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstraction.ApplicationServices
{
    public interface IApplicationServices
    {
        List<Menu> GetAuthorizeDefinitonEndpoints(Type type);
    }
}
