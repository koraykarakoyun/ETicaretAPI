using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Order.Query.GetByIdUserOrderDetail
{
    public class GetByIdUserOrderDetailQueryRequest:IRequest<GetByIdUserOrderDetailQueryResponse>
    {
        public string OrderCode { get; set; }
    }
}
