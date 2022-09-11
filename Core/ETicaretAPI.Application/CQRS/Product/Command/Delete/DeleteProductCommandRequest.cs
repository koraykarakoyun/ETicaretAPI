﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Command.Delete
{
    public class DeleteProductCommandRequest:IRequest<DeleteProductCommandResponse>
    {
        public string Id { get; set; }
    }
}
