using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Slider.Command.UpdateByIdSlidePhoto
{
    public class DeleteByIdSlidePhotoCommandRequest:IRequest<DeleteByIdSlidePhotoCommandResponse>
    {
        public string Id { get; set; }
    }
}
