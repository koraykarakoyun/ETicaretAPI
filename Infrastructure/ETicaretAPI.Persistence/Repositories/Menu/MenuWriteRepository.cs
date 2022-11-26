using ETicaretAPI.Application.Repositories.Menu;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.Menu
{
    public class MenuWriteRepository : WriteRepsitory<Domain.Entities.Menu>, IMenuWriteRepository
    {
        public MenuWriteRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}
