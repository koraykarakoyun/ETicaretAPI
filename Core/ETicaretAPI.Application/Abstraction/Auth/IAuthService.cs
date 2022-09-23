using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstraction.Auth
{
    public interface IAuthService:IInternalAuthService,IExternalAuthService
    {
    }
}
