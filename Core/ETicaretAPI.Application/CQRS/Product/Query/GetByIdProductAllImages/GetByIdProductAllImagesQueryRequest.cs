using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetByIdProductAllImages
{
    public class GetByIdProductAllImagesQueryRequest:IRequest<List<GetByIdProductAllImagesQueryResponse>>
    {
        public string Id { get; set; }
    }
}
