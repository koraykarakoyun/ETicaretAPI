using ETicaretAPI.Application.Abstraction.Storage;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.ProductImageFile;
using ETicaretAPI.Domain.Entities;
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
        readonly IStorageService _storageService;

        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        readonly IProductReadRepository _productReadRepository;

        public ImageUploadProductCommandHandler(IProductImageFileWriteRepository productImageFileWriteRepository, IStorageService storageService, IProductReadRepository productReadRepository)
        {

            _productImageFileWriteRepository = productImageFileWriteRepository;
            _storageService = storageService;
            _productReadRepository = productReadRepository;
        }

        public async Task<ImageUploadProductCommandResponse> Handle(ImageUploadProductCommandRequest request, CancellationToken cancellationToken)
        {
            //dosyayı sunucuya yükleme işlemi(wwwroot)
            (IFormFile uploadedfile, string uploadedpath) = await _storageService.UploadAsync("resource/product-images", request.formcollection.Files);


            Domain.Entities.Product product = await _productReadRepository.GetByIdAsync(request.ProductId);
             
            //dosya bilgilerini veritabanına (productimagefiles tablosuna) kaydetme işlemi
            bool result = await _productImageFileWriteRepository.AddAsync(new() { FileName = uploadedfile.FileName, Path = uploadedpath, Products = new List<Domain.Entities.Product>(){product}});






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
