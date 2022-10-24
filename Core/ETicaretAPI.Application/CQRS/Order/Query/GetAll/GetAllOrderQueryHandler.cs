using ETicaretAPI.Application.Abstraction.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Order.Query.GetAll
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, List<GetAllOrderQueryResponse>>
    {
        IOrderService _orderService;

        public GetAllOrderQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<List<GetAllOrderQueryResponse>> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        {

            var data = await _orderService.GetAllOrder();

            return data.Select(a => new GetAllOrderQueryResponse()
            {
                OrderBasketId = a.OrderBasketId,
                OrderCode = a.OrderCode,
                UserName = a.UserName,
                Description = a.Description,
                Address = a.Address,
                TotalPrice = a.TotalPrice,
                CreatedDate = a.CreatedDate

            }).ToList();
        }
    }
}
