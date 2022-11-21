using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Order.Command.CompleteOrder
{
    public class CompletedOrderCommandResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
