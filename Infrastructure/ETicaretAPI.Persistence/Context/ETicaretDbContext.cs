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
    public class ETicaretDbContext : IdentityDbContext<AppUser, AppRole, string>
    {


        public ETicaretDbContext(DbContextOptions options) : base(options)
        {
        }

        //Main Tables
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        //File Tables
        public DbSet<ETicaretAPI.Domain.Entities.File.File> Files { get; set; }

        public DbSet<ETicaretAPI.Domain.Entities.File.ProductImageFile> ProductImageFiles { get; set; }

        public DbSet<ETicaretAPI.Domain.Entities.File.InvoiceFile> InvoiceFiles { get; set; }

        //Basket Tables
        public DbSet<ETicaretAPI.Domain.Entities.Basket> Baskets { get; set; }
        public DbSet<ETicaretAPI.Domain.Entities.BasketItem> BasketItems { get; set; }

        public DbSet<Domain.Entities.CompletedOrder> CompletedOrders { get; set; }

        public DbSet<Domain.Entities.Menu> Menus { get; set; }

        public DbSet<Domain.Entities.Endpoint> Endpoints { get; set; }

        public DbSet<Domain.Entities.UserAuthRole> UserAuthRoles { get; set; }

        public DbSet<Domain.Entities.Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<Order>()
               .HasKey(b => b.Id);

            builder.Entity<Order>()
                .HasIndex(o => o.OrderCode)
                .IsUnique();

            builder.Entity<ETicaretAPI.Domain.Entities.Basket>()
                .HasOne(b => b.Order)
                .WithOne(o => o.Basket)
                .HasForeignKey<Order>(b => b.Id);
            //order'in "id" si ile  basket "id" si "bire bir iliski" ile baglandi.

            builder.Entity<Order>().HasOne(o => o.CompletedOrder).WithOne(o => o.Order).HasForeignKey<CompletedOrder>(o => o.OrderId);

            builder.Entity<Product>().HasOne(a => a.Category).WithMany(a => a.Products).HasForeignKey(a=>a.CategoryId);


            base.OnModelCreating(builder);
        }

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
