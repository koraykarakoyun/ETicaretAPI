using ETicaretAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Command.Add
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;

        public AddProductCommandHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productWriteRepository.AddAsync(
                new() { Name = request.Name, Stock = request.Stock, Price = request.Price }
                );
            await _productWriteRepository.SaveAsync();

            return new AddProductCommandResponse { Message = "Eklendi", IsSuccess = true };

        }
    }
}
