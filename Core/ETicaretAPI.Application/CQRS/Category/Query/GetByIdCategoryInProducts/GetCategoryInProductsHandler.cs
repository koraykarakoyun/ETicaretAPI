using ETicaretAPI.Application.Abstraction.Category;
using ETicaretAPI.Application.CQRS.Category.Query.GetByNameCategoryInProducts;
using ETicaretAPI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Category.Query.GetCategoryInProducts
{
    public class GetCategoryInProductsHandler : IRequestHandler<GetCategoryInProductsRequest, List<GetCategoryInProductsResponse>>
    {
        ICategoryService _categoryService;

        public GetCategoryInProductsHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<List<GetCategoryInProductsResponse>> Handle(GetCategoryInProductsRequest request, CancellationToken cancellationToken)
        {
            List<GetByIdCategoryInProductsDto> getCategoryInProductsDtos = await _categoryService.GetByIdCategoryInProductsAsync(request.CategoryId);

            return getCategoryInProductsDtos.Where(a => a.ShowCase == true).Select(a => new GetCategoryInProductsResponse()
            {
                CategoryId = a.CategoryId,
                CategoryName = a.CategoryName,
                ProductId = a.ProductId,
                ProductName = a.ProductName,
                ProductPrice = a.ProductPrice,
                ProductStock = a.ProductStock,
                Path = a.Path,
            }).ToList();
        }
    }
}
