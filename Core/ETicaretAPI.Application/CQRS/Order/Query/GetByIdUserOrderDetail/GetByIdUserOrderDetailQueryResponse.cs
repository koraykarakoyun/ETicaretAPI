using ETicaretAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Order.Query.GetByIdUserOrderDetail
{
    public class GetByIdUserOrderDetailQueryResponse
    {
        public GetByIdUserOrderDetailDto Data { get; set; }
    }
}
