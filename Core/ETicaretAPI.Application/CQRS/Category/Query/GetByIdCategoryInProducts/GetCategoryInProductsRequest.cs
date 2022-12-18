using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Category.Query.GetCategoryInProducts
{
    public class GetCategoryInProductsRequest:IRequest<List<GetCategoryInProductsResponse>>
    {
        public string CategoryId { get; set; }
    }
}
