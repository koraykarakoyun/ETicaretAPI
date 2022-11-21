using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Order.Query.GetAll
{
    public class GetAllOrderQueryResponse
    {
        public string OrderBasketId { get; set; }
        public string OrderCode { get; set; }

        public string UserName { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string TotalPrice { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool OrderCompleted { get; set; }

    }
}
