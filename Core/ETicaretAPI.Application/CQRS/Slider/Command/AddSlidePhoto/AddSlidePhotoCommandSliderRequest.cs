using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Slider.Command.AddSlidePhoto
{
    public class AddSlidePhotoCommandSliderRequest:IRequest<AddSlidePhotoCommandSliderResponse>
    {
        public IFormCollection formcollection { get; set; }

    }
}
