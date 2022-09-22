using ETicaretAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.User.Command.FacebookLogin
{
    public class FacebookLoginCommandResponse
    {
        public DTOs.Token Token { get; set; }
    }
}
