using ETicaretAPI.Application.Abstraction.Category;
using ETicaretAPI.Application.CQRS.Category.Query.GetByNameCategoryInProducts;
using ETicaretAPI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Category.Query.SortCategoryInProducts
{
    public class SortCategoryInProductsQueryHandler : IRequestHandler<SortCategoryInProductsQueryRequest, List<SortCategoryInProductsQueryResponse>>
    {
        ICategoryService _categoryService;

        public SortCategoryInProductsQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<List<SortCategoryInProductsQueryResponse>> Handle(SortCategoryInProductsQueryRequest request, CancellationToken cancellationToken)
        {
          List<SortCategoryInProductsDto> result= await _categoryService.SortCategoryInProductsAsync(request.Category, request.Type, request.Parameter);

            return result.Where(a => a.ShowCase == true).Select(a => new SortCategoryInProductsQueryResponse()
            {
                CategoryId = a.CategoryId,
                CategoryName = a.CategoryName,
                ProductId = a.ProductId,
                ProductName = a.ProductName,
                ProductPrice = a.ProductPrice,
                ProductStock = a.ProductStock,
                ProductPath = a.Path
            }).ToList();
        }
    }
}
