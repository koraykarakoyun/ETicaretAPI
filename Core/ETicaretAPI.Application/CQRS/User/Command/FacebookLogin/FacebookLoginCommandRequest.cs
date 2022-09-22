using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.User.Command.FacebookLogin
{
    public class FacebookLoginCommandRequest:IRequest<FacebookLoginCommandResponse>
    {
        public string AccessToken { get; set; }
    }
}
