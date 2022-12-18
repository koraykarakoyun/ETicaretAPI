using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetImage
{
    public class GetImageProductCommandResponse
    {
        public string ProductId { get; set; }
        public string Path { get; set; }

        public string FileName { get; set; }
    }
}
