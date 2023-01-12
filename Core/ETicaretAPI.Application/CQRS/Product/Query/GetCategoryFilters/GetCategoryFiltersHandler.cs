using ETicaretAPI.Application.Abstraction.Product;
using ETicaretAPI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetFilteredCategoryProducts
{
    public class GetCategoryFiltersHandler : IRequestHandler<GetCategoryFiltersRequest, GetCategoryFiltersResponse>
    {

        IProductService _productService;

        public GetCategoryFiltersHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<GetCategoryFiltersResponse> Handle(GetCategoryFiltersRequest request, CancellationToken cancellationToken)
        {
            GetCategoryFiltersDto getCategoryFiltersDtos = await _productService.GetCategoryFiltersAsync(request.Category);

            return new GetCategoryFiltersResponse()
            {
                Brands = getCategoryFiltersDtos.Brands,
                Models = getCategoryFiltersDtos.Models,
                Colors = getCategoryFiltersDtos.Colors
            };
        }
    }
}
