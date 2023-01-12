using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
    public class GetCategoryFiltersDto
    {
        public List<string> Brands { get; set; }

        public List<string> Models { get; set; }

        public List<string> Colors { get; set; }
    }
}
