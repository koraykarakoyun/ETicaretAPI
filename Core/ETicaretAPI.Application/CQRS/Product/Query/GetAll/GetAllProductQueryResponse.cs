using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.File;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetAll
{
    public class GetAllProductQueryResponse
    {

        public string Id { get; set; }
        public string Name { get; set; }

        public int Stock { get; set; }

        public float Price { get; set; }

        public string Path { get; set; }

        public ICollection<ProductImageFile> productImageFile { get; set; }



    }
}
