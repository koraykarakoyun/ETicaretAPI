using ETicaretAPI.Application.Abstraction.Basket;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.ProductImageFile;
using ETicaretAPI.Domain.Entities.File;
using MediatR;
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


            return _productImageFileReadRepository.Table.Include(p => p.Products).Where(a => a.ShowCase == true)
            .SelectMany(p => p.Products, (p, i) =>
            new GetAllProductQueryResponse()
            {

                ProductId = i.Id.ToString(),
                ProductName = i.Name,
                ProductPrice = i.Price,
                ProductStock = i.Stock,
                Path = p.Path
            }).ToList();




        }
    }
}
