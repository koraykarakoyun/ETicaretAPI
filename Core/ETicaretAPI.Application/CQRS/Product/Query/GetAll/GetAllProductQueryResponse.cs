using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetAll
{
    public class GetAllProductQueryResponse
    {

        public string Id { get; set; }
        public string Name { get; set; }

        public int Stock { get; set; }

        public float Price { get; set; }

    }
}
