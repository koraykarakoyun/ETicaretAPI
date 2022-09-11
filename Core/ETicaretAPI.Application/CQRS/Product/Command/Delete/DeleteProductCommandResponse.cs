using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Command.Delete
{
    public class DeleteProductCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
