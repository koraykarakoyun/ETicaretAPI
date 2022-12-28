using ETicaretAPI.Application.Abstraction.Order;
using ETicaretAPI.Application.Abstraction.User;
using ETicaretAPI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Order.Query.GetByIdUserOrderDetail
{
    public class GetByIdUserOrderDetailQueryHandler : IRequestHandler<GetByIdUserOrderDetailQueryRequest, GetByIdUserOrderDetailQueryResponse>
    {
        IOrderService _orderService;

        public GetByIdUserOrderDetailQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<GetByIdUserOrderDetailQueryResponse> Handle(GetByIdUserOrderDetailQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetByIdUserOrderDetailDto> result = await _orderService.GetByIdUserOrderDetail(request.OrderCode);

            return new GetByIdUserOrderDetailQueryResponse()
            {
                Data = result
            };
        }
    }
}
