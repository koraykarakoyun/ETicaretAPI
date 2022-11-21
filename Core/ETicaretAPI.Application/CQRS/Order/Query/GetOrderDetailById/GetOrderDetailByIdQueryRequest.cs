using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Order.Query.GetOrderDetailById
{
    public class GetOrderDetailByIdQueryRequest:IRequest<GetOrderDetailByIdQueryResponse>
    {
        public string OrderId { get; set; }
    }
}
