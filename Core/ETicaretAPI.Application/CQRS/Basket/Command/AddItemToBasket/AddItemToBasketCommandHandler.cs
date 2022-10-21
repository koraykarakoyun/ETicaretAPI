using ETicaretAPI.Application.Abstraction.Basket;
using ETicaretAPI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Basket.Command.Add
{
    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommandRequest, AddItemToBasketCommandResponse>
    {
        IBasketService _basketService;

        public AddItemToBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<AddItemToBasketCommandResponse> Handle(AddItemToBasketCommandRequest request, CancellationToken cancellationToken)
        {

            bool result=await _basketService.AddItemToBasketAsync(new Create_BasketItem { ProductId = request.ProductId, Quantity = request.Quantity });

            if (result)
            {
                return new AddItemToBasketCommandResponse()
                {
                    IsSuccess=true,
                    Message="Urun Sepete Eklenmistir"
                };
            }

            throw new Exception("Sepete eklenirken hata olustu");

        }
    }
}
