using ETicaretAPI.Application.Abstraction.Category;
using ETicaretAPI.Application.Abstraction.SignalR;
using ETicaretAPI.Application.Abstraction.Storage;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.ProductDetail;
using ETicaretAPI.Application.Repositories.ProductDetails;
using ETicaretAPI.Application.Repositories.ProductImageFile;
using ETicaretAPI.Domain.Entities.File;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Command.Add
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;
        readonly ILogger<AddProductCommandHandler> _logger;
        readonly IProductHubService _productHubService;
        IStorageService _storageService;
        readonly IProductReadRepository _productReadRepository;
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        IProductImageFileReadRepository _productImageFileReadRepository;
        ICategoryService _categoryService;
        IProductDetailReadRepository _productDetailReadRepository;
        IProductDetailWriteRepository _productDetailWriteRepository;
        public AddProductCommandHandler(IProductWriteRepository productWriteRepository, ILogger<AddProductCommandHandler> logger, IProductHubService productHubService, IStorageService storageService, IProductReadRepository productReadRepository, IProductImageFileWriteRepository productImageFileWriteRepository, IProductImageFileReadRepository productImageFileReadRepository, ICategoryService categoryService, IProductDetailReadRepository productDetailReadRepository, IProductDetailWriteRepository productDetailWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _logger = logger;
            _productHubService = productHubService;
            _storageService = storageService;
            _productReadRepository = productReadRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _productImageFileReadRepository = productImageFileReadRepository;
            _categoryService = categoryService;
            _productDetailReadRepository = productDetailReadRepository;
            _productDetailWriteRepository = productDetailWriteRepository;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {

            Domain.Entities.Category category= await _categoryService.GetByIdCategoryAsync(request.CategoryId);
            Domain.Entities.Product product = new Domain.Entities.Product()
            {
                Name = request.Name,
                Stock = request.Stock,
                Price = request.Price,
                Category=category,
                ProductDetail = new()
                {
                    Brand=request.Brand,
                    Model=request.Model,
                    Description=request.Description,
                    Color=request.Color
                }
            };
            await _productWriteRepository.AddAsync(product);
            await _productWriteRepository.SaveAsync();


            await _productImageFileWriteRepository.AddAsync(new() { FileName = "defaultimage.png", Path = "resource/product-images\\defaultimage.png", Products = new List<Domain.Entities.Product>() { product } });
            await _productImageFileWriteRepository.SaveAsync();




            Domain.Entities.Product product1 = await _productReadRepository.Table.Include(a => a.ProductImageFiles).FirstOrDefaultAsync(a => a.Id == product.Id);

            ProductImageFile? showcaseimage = product1.ProductImageFiles.First();

            showcaseimage.ShowCase = true;

            await _productImageFileWriteRepository.SaveAsync();




            return new AddProductCommandResponse { Message = "Eklendi", IsSuccess = true };



        }
    }
}
