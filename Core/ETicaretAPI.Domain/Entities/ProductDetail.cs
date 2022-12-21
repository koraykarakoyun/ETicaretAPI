using ETicaretAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class ProductDetail : BaseEntity
    {

        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }

        public Product Product { get; set; }
    }
}
