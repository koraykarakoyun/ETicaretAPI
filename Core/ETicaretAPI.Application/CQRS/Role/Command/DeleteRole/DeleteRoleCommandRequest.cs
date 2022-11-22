﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Role.Command.DeleteRole
{
    public class DeleteRoleCommandRequest:IRequest<DeleteRoleCommandResponse>
    {
        public string Id { get; set; }
    }
}
