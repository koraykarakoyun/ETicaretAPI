using ETicaretAPI.Application.Abstraction.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Command.ImageUpload
{
    public class ImageUploadProductCommandHandler : IRequestHandler<ImageUploadProductCommandRequest, ImageUploadProductCommandResponse>
    {

        readonly IFileServices _fileServices;

        public ImageUploadProductCommandHandler(IFileServices fileServices)
        {
            _fileServices = fileServices;
        }

        public async Task<ImageUploadProductCommandResponse> Handle(ImageUploadProductCommandRequest request, CancellationToken cancellationToken)
        {

            bool result = await _fileServices.UploadAsync("resource/product-images", request.formcollection.Files);

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
