using ETicaretAPI.Application.Abstraction.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Order.Command.CompleteOrder
{
    public class CompletedOrderCommandHandler : IRequestHandler<CompletedOrderCommandRequest, CompletedOrderCommandResponse>
    {
        IOrderService _orderService;

        public CompletedOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<CompletedOrderCommandResponse> Handle(CompletedOrderCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _orderService.CompleteOrderAsync(request.CompleteOrderId);
            if (result)
            {
                return new CompletedOrderCommandResponse()
                {
                    IsSuccess = true,
                    Message = "Siparişiniz Tamamlanmıştır"
                };
            }

            throw new Exception("Siparişiniz Tamamlanırken Hata Meydana gelmiştir");

        }
    }
}
