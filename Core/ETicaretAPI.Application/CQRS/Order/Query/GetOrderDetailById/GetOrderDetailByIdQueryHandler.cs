using ETicaretAPI.Application.Abstraction.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Order.Query.GetOrderDetailById
{
    public class GetOrderDetailByIdQueryHandler : IRequestHandler<GetOrderDetailByIdQueryRequest, GetOrderDetailByIdQueryResponse>
    {

        IOrderService _orderService;

        public GetOrderDetailByIdQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<GetOrderDetailByIdQueryResponse> Handle(GetOrderDetailByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _orderService.GetOrderDetailById(request.OrderId);

    

            return new GetOrderDetailByIdQueryResponse()
            {
                Id = data.Id,
                OrderCode = data.OrderCode,
                Address = data.Address,
                Description = data.Description,
                CreatedDate = data.CreatedDate,
               BasketItems=data.BasketItems,
            };

        }
    }
}
