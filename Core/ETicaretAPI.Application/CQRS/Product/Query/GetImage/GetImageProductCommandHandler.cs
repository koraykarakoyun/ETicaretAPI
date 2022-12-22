using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.ProductImageFile;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetImage
{
    public class GetImageProductCommandHandler : IRequestHandler<GetImageProductCommandRequest, List<GetImageProductCommandResponse>>
    {

        IProductReadRepository _productReadRepository;


        public GetImageProductCommandHandler(IProductReadRepository productReadRepository, IProductImageFileReadRepository productImageFileReadRepository)
        {
            _productReadRepository = productReadRepository;

        }

        public async Task<List<GetImageProductCommandResponse>> Handle(GetImageProductCommandRequest request, CancellationToken cancellationToken)
        {

            Domain.Entities.Product product = await _productReadRepository.Table.Include(p => p.ProductImageFiles).FirstOrDefaultAsync(id => id.Id == Guid.Parse(request.ProductId));


            return product.ProductImageFiles.Select(p => new GetImageProductCommandResponse
            {
                ProductId=p.Id.ToString(),
                FileName = p.FileName,
                ProductPath = p.Path,
                
            }).ToList();

        }
    }
}
