using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
    public class GetByIdUserOrderDetailProductInfoDto
    {

        public string CategoryName { get; set; }

        public string ProductId { get; set; }
        public string ProductName { get; set; }

        public float ProductPrice { get; set; }

        public int ProductQuantity { get; set; }

        public string ProductBrand { get; set; }
        public string ProductModel { get; set; }
        public string ProductDescription { get; set; }
        public string ProductColor { get; set; }

        public string Paths { get; set; }
    }
}
