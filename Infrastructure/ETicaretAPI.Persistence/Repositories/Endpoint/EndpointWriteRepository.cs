using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.Endpoint;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.Endpoint
{
    public class EndpointWriteRepository : WriteRepsitory<Domain.Entities.Endpoint>, IEndpointWriteRepository
    {
        public EndpointWriteRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}
