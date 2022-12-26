using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Basket.Query.GetBasketItem
{
    public class GetBasketItemQueryResponse
    {
        public string BasketItemId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductQuantity { get; set; }
        public string CategoryName { get; set; }
        public string ProductBrand { get; set; }
        public string ProductModel { get; set; }
        public string ProductDescription { get; set; }
        public string ProductColor { get; set; }

        public string ProductPath { get; set; }
        public bool ShowCase { get; set; }

        public string Count { get; set; }
    }
}
