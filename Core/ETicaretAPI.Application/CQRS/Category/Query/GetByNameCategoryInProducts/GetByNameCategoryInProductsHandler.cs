using ETicaretAPI.Application.Abstraction.Category;
using ETicaretAPI.Application.CQRS.Category.Query.GetCategoryInProducts;
using ETicaretAPI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Category.Query.GetByNameCategoryInProducts
{
    public class GetByNameCategoryInProductsHandler : IRequestHandler<GetByNameCategoryInProductsRequest, List<GetByNameCategoryInProductsResponse>>
    {
        ICategoryService _categoryService;

        public GetByNameCategoryInProductsHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<List<GetByNameCategoryInProductsResponse>> Handle(GetByNameCategoryInProductsRequest request, CancellationToken cancellationToken)
        {
            List<GetByNameCategoryInProductsDto> getByNameCategoryInProductsDtos = await _categoryService.GetByNameCategoryInProductsAsync(request.CategoryName);

            return getByNameCategoryInProductsDtos.Where(a => a.ShowCase == true).Select(a => new GetByNameCategoryInProductsResponse()
            {
                CategoryId = a.CategoryId,
                CategoryName = a.CategoryName,
                ProductId = a.ProductId,
                ProductName = a.ProductName,
                ProductPrice = a.ProductPrice,
                ProductStock = a.ProductStock,
                Path = a.Path
            }).ToList();
        }
    }
}
