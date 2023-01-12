using ETicaretAPI.Application.Abstraction.Category;
using ETicaretAPI.Application.Abstraction.Product;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.Category;
using ETicaretAPI.Application.Repositories.ProductDetails;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetAllFilter
{
    public class GetAllFilterQueryHandler : IRequestHandler<GetAllFilterQueryRequest, GetAllFilterQueryResponse>
    {
        IProductService _productService;

        public GetAllFilterQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

     
        public async Task<GetAllFilterQueryResponse> Handle(GetAllFilterQueryRequest request, CancellationToken cancellationToken)
        {
           var dto= await _productService.GetAllFiltersAsync();
            return new()
            {
                Brands = dto.Brands,
                Models = dto.Models,
                Categories = dto.Categories,
                Colors = dto.Colors
            };
        }
    }
}
