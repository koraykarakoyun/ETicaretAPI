using ETicaretAPI.Application.Abstraction.Services;
using ETicaretAPI.Application.Repositories.ProductImageFile;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using path = ETicaretAPI.Domain.Entities.File;

namespace ETicaretAPI.Application.CQRS.Product.Command.ImageUpload
{
    public class ImageUploadProductCommandHandler : IRequestHandler<ImageUploadProductCommandRequest, ImageUploadProductCommandResponse>
    {

        readonly IFileServices _fileServices;
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;

        public ImageUploadProductCommandHandler(IFileServices fileServices, IProductImageFileWriteRepository productImageFileWriteRepository)
        {
            _fileServices = fileServices;
            _productImageFileWriteRepository = productImageFileWriteRepository;
        }

        public async Task<ImageUploadProductCommandResponse> Handle(ImageUploadProductCommandRequest request, CancellationToken cancellationToken)
        {

            (IFormFile uploadedfile, string uploadedpath) = await _fileServices.UploadAsync("resource/product-images", request.formcollection.Files);

            bool result = await _productImageFileWriteRepository.AddAsync(new() { FileName = uploadedfile.FileName, Path = uploadedpath });
            await _productImageFileWriteRepository.SaveAsync();


            if (!result)
            {
                throw new Exception();
            }

            return new ImageUploadProductCommandResponse()
            {
                issucess = true,
                Message = "urun resmi eklendi"
            };
        }
    }
}
