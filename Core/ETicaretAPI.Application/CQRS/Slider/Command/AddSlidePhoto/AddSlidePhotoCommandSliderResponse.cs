using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Slider.Command.AddSlidePhoto
{
    public class AddSlidePhotoCommandSliderResponse
    {
        public string Message { get; set; }
        public bool issucess { get; set; }
    }
}
