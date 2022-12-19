using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Slider.Query.GetAllSlidePhotos
{
    public class GetAllSlidePhotosQuerySliderRequest:IRequest<List<GetAllSlidePhotosQuerySliderResponse>>
    {
    }
}
