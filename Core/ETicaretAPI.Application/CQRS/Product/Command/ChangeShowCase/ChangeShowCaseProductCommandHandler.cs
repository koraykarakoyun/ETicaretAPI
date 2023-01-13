using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.File;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Command.ChangeShowCase
{
    public class ChangeShowCaseProductCommandHandler : IRequestHandler<ChangeShowCaseProductCommandRequest, ChangeShowCaseProductCommandResponse>
    {


        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;

        public ChangeShowCaseProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<ChangeShowCaseProductCommandResponse> Handle(ChangeShowCaseProductCommandRequest request, CancellationToken cancellationToken)
        {

            var product = await _productReadRepository.Table.Include(a => a.ProductImageFiles).FirstOrDefaultAsync(a => a.Id == Guid.Parse(request.ProductId));

            List<ProductImageFile> productImageFiles = product.ProductImageFiles.ToList();

            foreach (var item in productImageFiles)
            {
                item.ShowCase = false;
            }

            ProductImageFile productImageFile = product.ProductImageFiles.FirstOrDefault(a => a.Id == Guid.Parse(request.ImageId));
            if (productImageFile != null)
            {
                productImageFile.ShowCase = true;
                await _productWriteRepository.SaveAsync();

                return new()
                {
                    IsSuccess = true,
                    Message = "Vitrin Resmi Değiştirildi"
                };
            }

            return new()
            {
                IsSuccess = false,
                Message = "Vitrin Resmi Değiştirilirken Hata Oluştu"
            };





        }
    }
}
