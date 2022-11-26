using ETicaretAPI.Application.Repositories.Endpoint;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.Endpoint
{
    public class EndpointReadRepository : ReadRepository<Domain.Entities.Endpoint>, IEndpointReadRepository
    {
        public EndpointReadRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}
