using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
    public class GetByIdUserOrderDetailDto
    {
        public GetByIdUserOrderDetailDto()
        {
            Paths = new List<string>();
        }
        public string CategoryName { get; set; }

        public string ProductName { get; set; }

        public float ProductPrice { get; set; }

        public int ProductQuantity { get; set; }

        public string ProductBrand { get; set; }
        public string ProductModel { get; set; }
        public string ProductDescription { get; set; }
        public string ProductColor { get; set; }

        public string OrderDescription { get; set; }

        public string OrderAddress { get; set; }

        public string OrderCode { get; set; }

        public DateTime OrderCreatedDate { get; set; }

        public List<string> Paths { get; set; }

        public string TotalPrice { get; set; }


    }
}
