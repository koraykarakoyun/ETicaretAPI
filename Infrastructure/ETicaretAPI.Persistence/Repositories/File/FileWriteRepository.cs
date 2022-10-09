using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.File
{
    public class FileWriteRepository : WriteRepsitory<Domain.Entities.File.File>, IFileWriteRepository
    {
        public FileWriteRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}
