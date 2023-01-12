using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Order.Command.DeleteOrderByOrderCode
{
    public class DeleteOrderByOrderCodeCommandRequest:IRequest<DeleteOrderByOrderCodeCommandResponse>
    {
        public string OrderCode { get; set; }
    }
}
