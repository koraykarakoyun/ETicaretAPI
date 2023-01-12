using ETicaretAPI.Application.Abstraction.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Order.Command.DeleteOrderByOrderCode
{
    public class DeleteOrderByOrderCodeCommandHandler : IRequestHandler<DeleteOrderByOrderCodeCommandRequest, DeleteOrderByOrderCodeCommandResponse>
    {
        IOrderService _orderService;

        public DeleteOrderByOrderCodeCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<DeleteOrderByOrderCodeCommandResponse> Handle(DeleteOrderByOrderCodeCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _orderService.DeleteOrderByOrderCodeAsync(request.OrderCode);
            if (result)
            {
                return new()
                {
                    IsSuccess = true,
                    Message = "Sipariş Silinmiştir"
                };
            }

            throw new Exception("Sipariş Bulunamadı");

        }
    }
}
