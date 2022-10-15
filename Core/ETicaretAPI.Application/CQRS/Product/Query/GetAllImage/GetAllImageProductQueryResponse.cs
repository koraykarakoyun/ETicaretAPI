using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetAllImage
{
    public class GetAllImageProductQueryResponse
    {


        public string Id { get; set; }
        public string Name { get; set; }

        public int Stock { get; set; }

        public float Price { get; set; }

        public string Path { get; set; }

        public string FileName { get; set; }

    }
}
