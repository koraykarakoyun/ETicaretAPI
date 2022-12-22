using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetAllImage
{
    public class GetAllImageProductQueryResponse
    {


        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public float ProductPrice { get; set; }

        public string ProductPath { get; set; }
        public string FileName { get; set; }

        public string ProductBrand { get; set; }
        public string ProductModel { get; set; }
        public string ProductDescription { get; set; }
        public string ProductColor { get; set; }

    }
}
