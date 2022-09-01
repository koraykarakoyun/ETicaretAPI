using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public class DesingTimeDbContextFactory : IDesignTimeDbContextFactory<ETicaretDbContext>
    {
        public ETicaretDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ETicaretDbContext> dbContextOptionsBuilder = new();

            dbContextOptionsBuilder.UseSqlServer("Server=DESKTOP-2AMEV92;Database=ETicaretApi;Trusted_Connection=True;");

            return new(dbContextOptionsBuilder.Options);
        }
    }
}
