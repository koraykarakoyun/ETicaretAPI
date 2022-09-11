using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetById
{
    public class GetByIdProductQueryResponse
    {
        public string Name { get; set; }

        public int Stock { get; set; }

        public float Price { get; set; }
    }
}
