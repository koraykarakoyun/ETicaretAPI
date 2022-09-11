using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Command.Add
{
    public class AddProductCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
