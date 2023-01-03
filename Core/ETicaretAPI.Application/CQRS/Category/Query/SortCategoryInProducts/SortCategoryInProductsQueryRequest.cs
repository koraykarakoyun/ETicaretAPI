using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Category.Query.SortCategoryInProducts
{
    public class SortCategoryInProductsQueryRequest:IRequest<List<SortCategoryInProductsQueryResponse>>
    {
        public string Category { get; set; }
        public string Type { get; set; }
        public string Parameter { get; set; }
    }
}
