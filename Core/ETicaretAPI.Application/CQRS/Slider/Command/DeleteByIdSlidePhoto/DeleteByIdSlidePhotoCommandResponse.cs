using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Slider.Command.UpdateByIdSlidePhoto
{
    public class DeleteByIdSlidePhotoCommandResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
