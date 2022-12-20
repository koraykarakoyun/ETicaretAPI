using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.SearchProducts
{
    public class SearchProductsQueryRequest:IRequest<List<SearchProductsQueryResponse>>
    {
        public string word { get; set; }
    }
}
