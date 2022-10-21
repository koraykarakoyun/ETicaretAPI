using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Basket.Command.UpdateBasketItem
{
    public class UpdateBasketItemCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
