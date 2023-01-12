using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetAllFilter
{
    public class GetAllFilterQueryResponse
    {
        public List<string> Brands { get; set; }

        public List<string> Models { get; set; }

        public List<string> Colors { get; set; }
        public List<string> Categories { get; set; }
    }
}
