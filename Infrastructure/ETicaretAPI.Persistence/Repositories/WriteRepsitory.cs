using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class WriteRepsitory<T> : IWriteRepository<T> where T : BaseEntity
    {

        ETicaretDbContext _context;

        public WriteRepsitory(ETicaretDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;

        }

        public async Task<bool> AddRangeAsync(List<T> model)
        {

            await Table.AddRangeAsync(model);
            return true;


        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);

            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveByIdAsync(string id)
        {
            var result = await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            EntityEntry<T> entityEntry = Table.Remove(result);

            return entityEntry.State == EntityState.Deleted;

        }

        public bool RemoveRange(List<T> model)
        {
            Table.RemoveRange(model);
            return true;

        }

        public bool Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;

        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
           
        }
    }
}
