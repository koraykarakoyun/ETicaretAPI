using ETicaretAPI.Application.Abstraction.Basket;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.ProductImageFile;
using ETicaretAPI.Domain.Entities.File;
using MediatR;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetAll
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        IProductImageFileReadRepository _productImageFileReadRepository;
        IProductReadRepository _productReadRepository;
        ILogger<GetAllProductQueryHandler> _logger;


        public GetAllProductQueryHandler(IProductReadRepository productReadRepository, ILogger<GetAllProductQueryHandler> logger, IProductImageFileReadRepository productImageFileReadRepository)
        {
            _productReadRepository = productReadRepository;
            _logger = logger;
            _productImageFileReadRepository = productImageFileReadRepository;
        }

        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {

            var productsdto = _productReadRepository.Table.Include(a => a.ProductImageFiles).Include(a => a.ProductDetail).Where(a => a.ProductImageFiles.Any(a => a.ShowCase == true)).SelectMany(p => p.ProductImageFiles, (i, p) =>
            new GetAllProductsDto()
            {

                ProductId = i.Id.ToString(),
                ProductName = i.Name,
                ProductPrice = i.Price,
                ProductStock = i.Stock,
                Brand = i.ProductDetail.Brand,
                Model = i.ProductDetail.Model,
                Description = i.ProductDetail.Description,
                Color = i.ProductDetail.Color,
                Path = p.Path,
                ShowCase = p.ShowCase,
            }).ToList();

            return productsdto.Where(a => a.ShowCase == true).Select(a => new GetAllProductQueryResponse()
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
