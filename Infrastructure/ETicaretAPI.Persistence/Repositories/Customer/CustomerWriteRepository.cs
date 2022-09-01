using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class CustomerWriteRepository : WriteRepsitory<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}
