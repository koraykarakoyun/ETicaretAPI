using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Order.Command.Create
{
    public class CreateOrderCommandResponse
    {
        public bool IsSuccess { get; set; }

        public string Messages { get; set; }
    }
}
