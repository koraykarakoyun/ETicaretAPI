using ETicaretAPI.Application.Abstraction.Category;
using ETicaretAPI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.SortAllProducts
{
    public class SortAllProductsQueryHandler : IRequestHandler<SortAllProductsQueryRequest, List<SortAllProductsQueryResponse>>
    {
        ICategoryService _categoryService;

        public SortAllProductsQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<List<SortAllProductsQueryResponse>> Handle(SortAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllProductsDto> getAllProductsDtos = await _categoryService.SortAllProductsAsync(request.Type, request.Parameter);
            return getAllProductsDtos.Select(a => new SortAllProductsQueryResponse()
            {
                ProductId = a.ProductId,
                ProductName = a.ProductName,
                ProductPrice = a.ProductPrice,
                ProductStock = a.ProductStock,
                ProductBrand = a.Brand,
                ProductModel = a.Model,
                ProductDescription = a.Description,
                ProductColor = a.Color,
                ProductPath = a.Path,
            }).ToList();

        }
    }
}
