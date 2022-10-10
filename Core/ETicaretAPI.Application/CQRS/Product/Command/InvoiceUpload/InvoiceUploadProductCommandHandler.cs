
using ETicaretAPI.Application.Abstraction.Storage;
using ETicaretAPI.Application.CQRS.Product.Command.ImageUpload;
using ETicaretAPI.Application.Repositories.InvoiceFile;
using ETicaretAPI.Application.Repositories.ProductImageFile;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Command.InvoiceUpload
{
    public class InvoiceUploadProductCommandHandler : IRequestHandler<InvoiceUploadProductCommandRequest, InvoiceUploadProductCommandResponse>
    {

        readonly IStorageService _storageService;
        readonly IInvoiceFileWriteRepository _ınvoiceFileWriteRepository;

        public InvoiceUploadProductCommandHandler(IInvoiceFileWriteRepository ınvoiceFileWriteRepository, IStorageService storageService)
        {

            _ınvoiceFileWriteRepository = ınvoiceFileWriteRepository;
            _storageService = storageService;
        }

        public async Task<InvoiceUploadProductCommandResponse> Handle(InvoiceUploadProductCommandRequest request, CancellationToken cancellationToken)
        {


            (IFormFile uploadedfile, string uploadedpath) = await _storageService.UploadAsync("resource/invoices", request.formcollection.Files);

            bool result = await _ınvoiceFileWriteRepository.AddAsync(new() { FileName = uploadedfile.FileName, Path = uploadedpath });
            await _ınvoiceFileWriteRepository.SaveAsync();


            if (!result)
            {
                throw new Exception();
            }

            return new ()
            {
                issucess = true,
                Message = "urun resmi eklendi"
            };

        }
    }
}
