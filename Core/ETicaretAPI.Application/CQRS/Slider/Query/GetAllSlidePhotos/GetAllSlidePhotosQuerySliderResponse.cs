using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Slider.Query.GetAllSlidePhotos
{
    public class GetAllSlidePhotosQuerySliderResponse
    {
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public bool ShowCase { get; set; }
    }
}
