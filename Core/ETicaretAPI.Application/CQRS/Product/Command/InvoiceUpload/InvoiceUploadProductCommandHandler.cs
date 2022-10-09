using ETicaretAPI.Application.Abstraction.Services;
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

        readonly IFileServices _fileServices;
        readonly IInvoiceFileWriteRepository _ınvoiceFileWriteRepository;

        public InvoiceUploadProductCommandHandler(IFileServices fileServices, IInvoiceFileWriteRepository ınvoiceFileWriteRepository)
        {
            _fileServices = fileServices;
            _ınvoiceFileWriteRepository = ınvoiceFileWriteRepository;
        }

        public async Task<InvoiceUploadProductCommandResponse> Handle(InvoiceUploadProductCommandRequest request, CancellationToken cancellationToken)
        {


            (IFormFile uploadedfile, string uploadedpath) = await _fileServices.UploadAsync("resource/invoices", request.formcollection.Files);

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
