using ETicaretAPI.Application.Abstraction.Basket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Basket.Command.RemoveItemToBasket
{
    public class RemoveItemToBasketCommanHandler : IRequestHandler<RemoveItemToBasketCommanRequest, RemoveItemToBasketCommanResponse>
    {
        IBasketService _basketService;

        public RemoveItemToBasketCommanHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<RemoveItemToBasketCommanResponse> Handle(RemoveItemToBasketCommanRequest request, CancellationToken cancellationToken)
        {
           bool result= await _basketService.RemoveBasketItemAsync(request.BasketItemId);

            if (result)
            {
                return new()
                {
                    IsSuccess = true,
                    Message = "Urun Sepetten Silinmistir"
                };
            }

            throw new Exception("Urun silinirken hata olustu");
        }
    }
}
