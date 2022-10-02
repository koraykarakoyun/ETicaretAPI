using ETicaretAPI.Application.Abstraction.SignalR;
using ETicaretAPI.Application.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
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
        readonly ILogger<AddProductCommandHandler> _logger;
        readonly IProductHubService _productHubService;

        public AddProductCommandHandler(IProductWriteRepository productWriteRepository, ILogger<AddProductCommandHandler> logger, IProductHubService productHubService)
        {
            _productWriteRepository = productWriteRepository;
            _logger = logger;
            _productHubService = productHubService;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("AddProduct Calistirildi");
            await _productWriteRepository.AddAsync(
                new() { Name = request.Name, Stock = request.Stock, Price = request.Price }
                );
            await _productWriteRepository.SaveAsync();

            await _productHubService.AddedProductMessage("SignalR urun ekleme islemi yapildi");
            return new AddProductCommandResponse { Message = "Eklendi", IsSuccess = true };



        }
    }
}
