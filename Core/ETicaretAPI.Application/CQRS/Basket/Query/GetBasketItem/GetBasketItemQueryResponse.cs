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
        public string Quantity { get; set; }
     
    }
}
