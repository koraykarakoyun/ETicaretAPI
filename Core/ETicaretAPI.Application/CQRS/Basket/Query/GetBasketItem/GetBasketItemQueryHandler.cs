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
            var itemCount= basketItems.Count();


            if (itemCount == 0)
            {
                List<string> nullcount = new List<string>();
                nullcount.Insert(index:0,"null");

                return nullcount.Select(item => new GetBasketItemQueryResponse()
                {
                    Count = itemCount.ToString(),
                }).ToList();
            }

            var totalquantity = 0;
            foreach (var item in basketItems)
            {
                totalquantity = totalquantity + item.Quantity;
            }

            return basketItems.Select(item => new GetBasketItemQueryResponse()
            {
                BasketItemId = item.Id.ToString(),
                ProductName = item.Product.Name,
                ProductPrice = item.Product.Price.ToString(),
                ProductQuantity = item.Quantity.ToString(),
                CategoryName = item.Product.Category.Name,
                ProductPath = item.Product.ProductImageFiles.FirstOrDefault(a => a.ShowCase == true).Path,
                ShowCase = item.Product.ProductImageFiles.FirstOrDefault(a => a.ShowCase == true).ShowCase,
                ProductModel = item.Product.ProductDetail.Model,
                ProductBrand = item.Product.ProductDetail.Brand,
                ProductDescription = item.Product.ProductDetail.Description,
                ProductColor = item.Product.ProductDetail.Color,
                Count= totalquantity.ToString()
            }).ToList();

        }
    }
}
