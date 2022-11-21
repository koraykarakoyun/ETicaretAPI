using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Order.Command.CompleteOrder
{
    public class CompletedOrderCommandRequest:IRequest<CompletedOrderCommandResponse>
    {
        public string CompleteOrderId { get; set; }
    }
}
