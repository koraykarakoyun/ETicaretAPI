using ETicaretAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        IProductReadRepository _productReadRepository;

        public GetByIdQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _productReadRepository.Table.Include(a => a.ProductDetail).Include(a => a.Category).SingleOrDefaultAsync(a => a.Id == Guid.Parse(request.Id));




            return new GetByIdProductQueryResponse
            {
                ProductId = response.Id.ToString(),
                ProductName = response.Name,
                ProductStock = response.Stock,
                ProductPrice = response.Price,
                ProductBrand = response.ProductDetail.Brand,
                ProductModel = response.ProductDetail.Model,
                ProductDescription = response.ProductDetail.Description,
                ProductColor = response.ProductDetail.Color,
                CategoryId = response.Category.Id.ToString(),
                CategoryName = response.Category.Name

            };
        }
    }
}
