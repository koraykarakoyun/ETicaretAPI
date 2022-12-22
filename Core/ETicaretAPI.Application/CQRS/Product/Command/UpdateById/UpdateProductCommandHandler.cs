
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.ProductDetail;
using ETicaretAPI.Application.Repositories.ProductDetails;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Command.UpdateById
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        IProductDetailReadRepository _productDetailReadRepository;
        IProductDetailWriteRepository _productDetailWriteRepository;

        public UpdateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IProductDetailReadRepository productDetailReadRepository, IProductDetailWriteRepository productDetailWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _productDetailReadRepository = productDetailReadRepository;
            _productDetailWriteRepository = productDetailWriteRepository;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {

            var query = await _productReadRepository.Table.Include(a => a.ProductDetail).SingleOrDefaultAsync(a => a.Id == Guid.Parse(request.Id));
            query.Name = request.Name;
            query.Price = request.Price;
            query.Stock = request.Stock;

            query.ProductDetail.Brand = request.Brand;
            query.ProductDetail.Model = request.Model;
            query.ProductDetail.Description = request.Description;
            query.ProductDetail.Color = request.Color;
            await _productWriteRepository.SaveAsync();
            await _productDetailWriteRepository.SaveAsync();
            return new UpdateProductCommandResponse { IsSuccess = true ,Message="Guncellendi"};
        }
    }
}
