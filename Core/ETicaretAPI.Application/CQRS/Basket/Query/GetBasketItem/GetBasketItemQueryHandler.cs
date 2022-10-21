using ETicaretAPI.Application.Abstraction.Basket;
using ETicaretAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Basket.Query.GetBasketItem
{
    public class GetBasketItemQueryHandler : IRequestHandler<GetBasketItemQueryRequest, List<GetBasketItemQueryResponse>>
    {
        IBasketService _basketService;

        public GetBasketItemQueryHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<List<GetBasketItemQueryResponse>> Handle(GetBasketItemQueryRequest request, CancellationToken cancellationToken)
        {

            List<BasketItem> basketItems = await _basketService.GetBasketItems();

            return basketItems.Select(item => new GetBasketItemQueryResponse()
            {
                BasketItemId = item.Id.ToString(),
                ProductName = item.Product.Name,
                ProductPrice = item.Product.Price.ToString(),
                Quantity = item.Quantity.ToString()
            }).ToList();

        }
    }
}
