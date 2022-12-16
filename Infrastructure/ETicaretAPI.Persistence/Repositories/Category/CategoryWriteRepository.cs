using ETicaretAPI.Application.Repositories.Category;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.Category
{
    public class CategoryWriteRepository : WriteRepsitory<Domain.Entities.Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}
