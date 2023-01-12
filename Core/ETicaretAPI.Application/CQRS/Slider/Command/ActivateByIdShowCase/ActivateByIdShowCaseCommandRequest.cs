using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Slider.Command.ActivateByIdShowCase
{
    public class ActivateByIdShowCaseCommandRequest:IRequest<ActivateByIdShowCaseCommandResponse>
    {
        public string Id { get; set; }
    }
}
