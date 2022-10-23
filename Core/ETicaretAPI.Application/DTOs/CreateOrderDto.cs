using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
    public class CreateOrderDto
    {
        public string Description { get; set; }

        public string Address { get; set; }
    }
}
