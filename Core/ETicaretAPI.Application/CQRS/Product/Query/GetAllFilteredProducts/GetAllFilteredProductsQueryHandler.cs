using ETicaretAPI.Application.Abstraction.Product;
using ETicaretAPI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetAllFilteredProducts
{
    public class GetAllFilteredProductsQueryHandler : IRequestHandler<GetAllFilteredProductsQueryRequest, List<GetAllFilteredProductsQueryResponse>>
    {
        IProductService _productService;

        public GetAllFilteredProductsQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<List<GetAllFilteredProductsQueryResponse>> Handle(GetAllFilteredProductsQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllFilteredProductsDto>? getAllFilteredProductsDtos = await _productService.GetAllFilteredProductsAsync(request.Brand, request.Model, request.Color, request.Category);
            return getAllFilteredProductsDtos.Select(a => new GetAllFilteredProductsQueryResponse()
            {
                ProductId = a.ProductId,
                ProductName = a.ProductName,
                ProductPrice = a.ProductPrice,
                ProductStock = a.ProductStock,
                Brand = a.Brand,
                Model = a.Model,
                Description = a.Description,
                Color = a.Color,
                Path = a.Path,
                ShowCase = a.ShowCase,
            }).ToList();
        }
    }
}
