using ETicaretAPI.Application.Abstraction.Basket;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.ProductImageFile;
using ETicaretAPI.Domain.Entities.File;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetAll
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {

        IProductReadRepository _productReadRepository;
        ILogger<GetAllProductQueryHandler> _logger;
        IProductImageFileReadRepository _productImageFileReadRepository;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository, ILogger<GetAllProductQueryHandler> logger, IProductImageFileReadRepository productImageFileReadRepository)
        {
            _productReadRepository = productReadRepository;
            _logger = logger;
        }

        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {

            return  _productReadRepository.GetAll().Include(p=>p.ProductImageFiles).Select(a => new GetAllProductQueryResponse
            {
                Id=a.Id.ToString(),
                Name=a.Name,
                Price=a.Price,
                Stock=a.Stock,
                productImageFile=a.ProductImageFiles

            }).ToList();

           
        }
    }
}
