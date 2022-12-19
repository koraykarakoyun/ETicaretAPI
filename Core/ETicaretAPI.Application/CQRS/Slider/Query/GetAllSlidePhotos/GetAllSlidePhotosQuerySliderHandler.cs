using ETicaretAPI.Application.Repositories.Slider;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Slider.Query.GetAllSlidePhotos
{
    public class GetAllSlidePhotosQuerySliderHandler : IRequestHandler<GetAllSlidePhotosQuerySliderRequest, List<GetAllSlidePhotosQuerySliderResponse>>
    {
        ISliderReadRepository _sliderReadRepository;

        public GetAllSlidePhotosQuerySliderHandler(ISliderReadRepository sliderReadRepository)
        {
            _sliderReadRepository = sliderReadRepository;
        }

        public async Task<List<GetAllSlidePhotosQuerySliderResponse>> Handle(GetAllSlidePhotosQuerySliderRequest request, CancellationToken cancellationToken)
        {
            return await _sliderReadRepository.GetAll().Select(a => new GetAllSlidePhotosQuerySliderResponse()
            {
                FileId=a.Id.ToString(),
                FileName = a.FileName,
                FilePath = a.Path,
                ShowCase = a.ShowCase
            }).ToListAsync();
        }
    }
}
