using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Category.Query.GetAllCategories
{
    public class GetAllCategoriesQueryResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
