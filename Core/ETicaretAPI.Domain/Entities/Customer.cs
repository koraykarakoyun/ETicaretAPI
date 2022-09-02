using ETicaretAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Customer:BaseEntity
    {
        public Guid Name { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
