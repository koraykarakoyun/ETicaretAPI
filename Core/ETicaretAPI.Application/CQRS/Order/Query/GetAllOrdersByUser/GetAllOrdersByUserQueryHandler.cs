using ETicaretAPI.Application.Abstraction.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Order.Query.GetAllOrdersByUser
{
    public class GetAllOrdersByUserQueryHandler : IRequestHandler<GetAllOrdersByUserQueryRequest, GetAllOrdersByUserQueryResponse>
    {
        IOrderService _orderService;

        public GetAllOrdersByUserQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<GetAllOrdersByUserQueryResponse> Handle(GetAllOrdersByUserQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _orderService.GetAllOrdersByUser();

            return new GetAllOrdersByUserQueryResponse()
            {
                Data = result
            };
            


        }
    }
}
