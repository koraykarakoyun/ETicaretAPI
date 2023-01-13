using ETicaretAPI.Application.CQRS.Slider.Command.AddSlidePhoto;
using ETicaretAPI.Application.Repositories.Slider;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Slider.Command.UpdateByIdSlidePhoto
{
    public class DeleteByIdSlidePhotoCommandHandler : IRequestHandler<DeleteByIdSlidePhotoCommandRequest, DeleteByIdSlidePhotoCommandResponse>
    {
        ISliderWriteRepository _sliderWriteRepository;
        ISliderReadRepository _sliderReadRepository;

        public DeleteByIdSlidePhotoCommandHandler(ISliderWriteRepository sliderWriteRepository, ISliderReadRepository sliderReadRepository)
        {
            _sliderWriteRepository = sliderWriteRepository;
            _sliderReadRepository = sliderReadRepository;
        }

        public async Task<DeleteByIdSlidePhotoCommandResponse> Handle(DeleteByIdSlidePhotoCommandRequest request, CancellationToken cancellationToken)
        {

            bool result = await _sliderWriteRepository.RemoveByIdAsync(request.Id);
            await _sliderWriteRepository.SaveAsync();

            if (!result)
            {
                return new DeleteByIdSlidePhotoCommandResponse()
                {
                    IsSuccess = true,
                    Message = "Resim Silinirken Hata Oluştu"
                };
            }

            return new DeleteByIdSlidePhotoCommandResponse()
            {
                IsSuccess = true,
                Message = "Resim silindi"
            };

        }
    }
}
