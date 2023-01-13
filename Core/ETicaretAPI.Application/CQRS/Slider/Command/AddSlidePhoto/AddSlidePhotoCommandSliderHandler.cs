using ETicaretAPI.Application.Abstraction.Storage;
using ETicaretAPI.Application.CQRS.Product.Command.ImageUpload;
using ETicaretAPI.Application.Repositories.Slider;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Slider.Command.AddSlidePhoto
{
    public class AddSlidePhotoCommandSliderHandler : IRequestHandler<AddSlidePhotoCommandSliderRequest, AddSlidePhotoCommandSliderResponse>
    {
        ISliderWriteRepository _sliderWriteRepository;
        ISliderReadRepository _sliderReadRepository;
        IStorageService _storageService;

        public AddSlidePhotoCommandSliderHandler(ISliderWriteRepository sliderWriteRepository, ISliderReadRepository sliderReadRepository, IStorageService storageService)
        {
            _sliderWriteRepository = sliderWriteRepository;
            _sliderReadRepository = sliderReadRepository;
            _storageService = storageService;
        }

        public async Task<AddSlidePhotoCommandSliderResponse> Handle(AddSlidePhotoCommandSliderRequest request, CancellationToken cancellationToken)
        {
            (IFormFile uploadedfile, string uploadedpath) = await _storageService.UploadAsync("resource/slider-images", request.formcollection.Files);
            bool result = await _sliderWriteRepository.AddAsync(new() { Id = Guid.NewGuid(), FileName = uploadedfile.FileName, Path = uploadedpath, ShowCase = true });
            await _sliderWriteRepository.SaveAsync();


            if (!result)
            {
                return new AddSlidePhotoCommandSliderResponse()
                {
                    IsSuccess = false,
                    Message = "Resmi Eklenirken Hata Oluştu"
                };
            }

            return new AddSlidePhotoCommandSliderResponse()
            {
                IsSuccess = true,
                Message = "Resmi eklendi"
            };
        }
    }
}
