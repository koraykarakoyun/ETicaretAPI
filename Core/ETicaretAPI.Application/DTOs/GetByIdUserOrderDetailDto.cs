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
            ProductInfo = new List<GetByIdUserOrderDetailProductInfoDto>();
        }

        public string OrderDescription { get; set; }

        public string OrderAddress { get; set; }

        public string OrderCode { get; set; }

        public DateTime OrderCreatedDate { get; set; }

        public string TotalPrice { get; set; }

        public string TotalProductCount { get; set; }

        public List<GetByIdUserOrderDetailProductInfoDto> ProductInfo { get; set; }

    }
}
