
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetAll
{
    public class GetAllProductQueryRequest:IRequest<List<GetAllProductQueryResponse>>
    {

    }
}
