using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Slider.Command.DeletByIdShowCase
{
    public class DeleteByIdShowCaseCommandSliderRequest:IRequest<DeleteByIdShowCaseCommandSliderResponse>
    {
        public string Id { get; set; }
    }
}
