using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Role.Command.CreateRole
{
    public class CreateRoleCommandResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
