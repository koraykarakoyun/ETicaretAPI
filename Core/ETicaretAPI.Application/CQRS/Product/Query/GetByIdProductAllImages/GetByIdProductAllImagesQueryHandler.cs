using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetByIdProductAllImages
{
    public class GetByIdProductAllImagesQueryHandler : IRequestHandler<GetByIdProductAllImagesQueryRequest, List<GetByIdProductAllImagesQueryResponse>>
    {

        IProductReadRepository _productReadRepository;

        public GetByIdProductAllImagesQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<List<GetByIdProductAllImagesQueryResponse>> Handle(GetByIdProductAllImagesQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product? product = await _productReadRepository.Table.Include(a => a.ProductImageFiles).SingleOrDefaultAsync(a => a.Id == Guid.Parse(request.Id));
            return product.ProductImageFiles.Select(a => new GetByIdProductAllImagesQueryResponse()
            {
                FilePath = a.Path
            }).ToList();
        }
    }
}
