using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Order.Query.GetAll
{
    public class GetAllOrderQueryRequest:IRequest<List<GetAllOrderQueryResponse>>
    {

    }
}
