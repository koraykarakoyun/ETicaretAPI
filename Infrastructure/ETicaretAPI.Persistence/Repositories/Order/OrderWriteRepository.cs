using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.Order;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.Order
{
    public class OrderWriteRepository : WriteRepsitory<Domain.Entities.Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}
