using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Command.InvoiceUpload
{
    public class InvoiceUploadProductCommandRequest:IRequest<InvoiceUploadProductCommandResponse>
    {
        public IFormCollection formcollection { get; set; }
    }
}
