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


            if (product.ProductImageFiles.Where(a => a.FileName != "defaultimage.png").Count() != 0)
            {
                return product.ProductImageFiles.Where(a => a.FileName != "defaultimage.png").Select(a => new GetByIdProductAllImagesQueryResponse()
                {
                    FilePath = a.Path
                }).ToList();
            }
            else
            {
                return product.ProductImageFiles.Where(a => a.FileName == "defaultimage.png").Select(a => new GetByIdProductAllImagesQueryResponse()
                {
                    FilePath = a.Path
                }).ToList();

            }

            throw new Exception("Fotograf Bulunamadı");

        }
    }
}
