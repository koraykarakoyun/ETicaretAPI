using ETicaretAPI.Domain.Common;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Context
{
    public class ETicaretDbContext : IdentityDbContext<AppUser,AppRole,string>
    {


        public ETicaretDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {

                if (data.State == EntityState.Added)
                {
                    data.Entity.CreatedDate = DateTime.Now;
                }

                else if (data.State == EntityState.Modified)
                {
                    data.Entity.UpdatedDate = DateTime.Now;
                }

            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
