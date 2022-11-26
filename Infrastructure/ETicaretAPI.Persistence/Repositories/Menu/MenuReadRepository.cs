using ETicaretAPI.Application.Repositories.Menu;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.Menu
{
    public class MenuReadRepository : ReadRepository<Domain.Entities.Menu>, IMenuReadRepository
    {
        public MenuReadRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}
