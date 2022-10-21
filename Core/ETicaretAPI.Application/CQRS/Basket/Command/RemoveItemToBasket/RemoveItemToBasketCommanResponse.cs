using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Basket.Command.RemoveItemToBasket
{
    public class RemoveItemToBasketCommanResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
