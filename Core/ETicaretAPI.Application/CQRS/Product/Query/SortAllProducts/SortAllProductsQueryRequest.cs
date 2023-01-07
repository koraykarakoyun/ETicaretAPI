using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.SortAllProducts
{
    public class SortAllProductsQueryRequest:IRequest<List<SortAllProductsQueryResponse>>
    {
        public string Type { get; set; }
        public string Parameter { get; set; }
    }
}
