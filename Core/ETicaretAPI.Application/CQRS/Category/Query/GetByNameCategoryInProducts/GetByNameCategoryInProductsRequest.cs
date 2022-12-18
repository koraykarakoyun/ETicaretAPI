using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Category.Query.GetByNameCategoryInProducts
{
    public class GetByNameCategoryInProductsRequest:IRequest<List<GetByNameCategoryInProductsResponse>>
    {
        public string CategoryName { get; set; }
    }
}
