
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.ViewModel;
using MediatR;
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

        public UpdateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {

            var query = await _productReadRepository.GetByIdAsync(request.Id);
            query.Name = request.Name;
            query.Price = request.Price;
            query.Stock = request.Stock;
            await _productWriteRepository.SaveAsync();
            return new UpdateProductCommandResponse { IsSuccess = true ,Message="Guncellendi"};
        }
    }
}
