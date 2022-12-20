using ETicaretAPI.Application.CQRS.Product.Query.GetAll;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.ProductImageFile;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.SearchProducts
{
    public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQueryRequest, List<SearchProductsQueryResponse>>
    {
        IProductImageFileReadRepository _productImageFileReadRepository;
        IProductReadRepository _productReadRepository;

        public SearchProductsQueryHandler(IProductImageFileReadRepository productImageFileReadRepository, IProductReadRepository productReadRepository)
        {
            _productImageFileReadRepository = productImageFileReadRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<List<SearchProductsQueryResponse>> Handle(SearchProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _productReadRepository.Table.Include(a => a.ProductImageFiles).Where(a => a.Name.Contains(request.word) && a.ProductImageFiles.Any(a => a.ShowCase == true)).SelectMany(p => p.ProductImageFiles, (p, i) =>
            new SearchProductsDto()
            {
                ProductId = p.Id.ToString(),
                ProductName = p.Name,
                ProductPrice = p.Price,
                ProductStock = p.Stock,
                Path = i.Path,
                ShowCase = i.ShowCase
            }).ToListAsync();

            return result.Where(a => a.ShowCase == true).Select(a => new SearchProductsQueryResponse()
            {
                ProductId = a.ProductId.ToString(),
                ProductName = a.ProductName,
                ProductPrice = a.ProductPrice,
                ProductStock = a.ProductStock,
                Path = a.Path,

            }).ToList();



        }
    }
}
