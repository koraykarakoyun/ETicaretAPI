using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {

       readonly ETicaretDbContext _context;

        public ReadRepository(ETicaretDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();


        public IQueryable<T> GetAll()
        {
            return Table;
        }

   
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        {
            return Table.Where(method);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            return await Table.FirstOrDefaultAsync(method);
        }
    }
}
