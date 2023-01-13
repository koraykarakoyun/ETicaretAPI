using ETicaretAPI.Application.Abstraction.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Order.Command.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        IOrderService _orderService;

        public CreateOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await _orderService.CreateOrder(new DTOs.CreateOrderDto
            {
                Address = request.Address,
                Description = request.Description

            });


            return new CreateOrderCommandResponse()
            {
                IsSuccess = true,
                Message = "Sepetiniz Basariyla Tamamlanmistir"
            };
        }
    }
}
