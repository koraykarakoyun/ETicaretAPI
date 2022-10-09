using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.File
{
    public class FileReadRepository : ReadRepository<Domain.Entities.File.File>, IFileReadRepository
    {
        public FileReadRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}
