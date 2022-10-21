using ETicaretAPI.Application.Abstraction.Basket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Basket.Command.UpdateBasketItem
{
    public class UpdateBasketItemCommandHandler : IRequestHandler<UpdateBasketItemCommandRequest, UpdateBasketItemCommandResponse>
    {

        IBasketService _basketService;

        public UpdateBasketItemCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<UpdateBasketItemCommandResponse> Handle(UpdateBasketItemCommandRequest request, CancellationToken cancellationToken)
        {
           bool result= await _basketService.UpdateQuantityAsync(new DTOs.Update_BasketItem()
            {
                BasketItemId=request.BasketItemId,
                Quantity=request.Quantity
            });

            if (result)
            {
                return new()
                {
                    IsSuccess = true,
                    Message = "Sepetteki Urun Guncellenmistir"
                };
            }

            throw new Exception("Urun Guncellenirken Hata Olustu");


        }
    }
}
