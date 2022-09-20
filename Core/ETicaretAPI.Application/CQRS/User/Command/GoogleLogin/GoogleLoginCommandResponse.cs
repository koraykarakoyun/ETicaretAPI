using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.User.Command.GoogleLogin
{
    public class GoogleLoginCommandResponse
    {
        public DTOs.Token Token { get; set; }

    }
}
