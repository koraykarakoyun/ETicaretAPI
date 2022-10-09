using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Command.InvoiceUpload
{
    public class InvoiceUploadProductCommandResponse
    {

        public string Message { get; set; }
        public bool issucess { get; set; }

    }
}
