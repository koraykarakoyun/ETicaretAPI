using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Basket.Command.RemoveItemToBasket
{
    public class RemoveItemToBasketCommanRequest:IRequest<RemoveItemToBasketCommanResponse>
    {

        public string BasketItemId { get; set; }
    }
}
