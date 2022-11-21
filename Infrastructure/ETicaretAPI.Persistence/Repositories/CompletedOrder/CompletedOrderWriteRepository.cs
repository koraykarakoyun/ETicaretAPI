using ETicaretAPI.Application.Repositories.CompletedOrder;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.CompletedOrder
{
    public class CompletedOrderWriteRepository : WriteRepsitory<Domain.Entities.CompletedOrder>, ICompletedOrderWriteRepository
    {
        public CompletedOrderWriteRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}
