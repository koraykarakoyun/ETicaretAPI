using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetImage
{
    public class GetImageProductCommandRequest:IRequest<List<GetImageProductCommandResponse>>
    {
        public string ProductId { get; set; }
    }
}
