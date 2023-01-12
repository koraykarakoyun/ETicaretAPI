using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Order.Command.DeleteOrderByOrderCode
{
    public class DeleteOrderByOrderCodeCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
