using ETicaretAPI.Application.CQRS.Product.Query.GetAll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetAllImage
{
    public class GetAllImageProductQueryRequest:IRequest<List<GetAllImageProductQueryResponse>>
    {
    }
}
