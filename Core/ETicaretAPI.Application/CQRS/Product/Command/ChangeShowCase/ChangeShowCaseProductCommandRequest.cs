using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Command.ChangeShowCase
{
    public class ChangeShowCaseProductCommandRequest:IRequest<ChangeShowCaseProductCommandResponse>
    {

        public string ProductId { get; set; }

        public string ImageId { get; set; }

    }
}
