using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Infrastructure.Data
{
    public class CustomerAppContext:DbContext
    {
        public CustomerAppContext(DbContextOptions<CustomerAppContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.Customer)
            //    .WithMany(c => c.Orders)
            //    .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Fine>()
                .HasOne(f => f.Customer)
                .WithMany(c => c.Fines)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Fine>()
                .HasMany(f => f.FineLines)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<FineLine>()
                .HasOne(x => x.FineType)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<FineLine>()
                .HasOne(x => x.Fine)
                .WithMany();

            //modelBuilder.Entity<Fine>()
            //    .HasOne(f => f.Customer)
            //    .WithMany(f => f.Fines)
            //    .OnDelete(DeleteBehavior.SetNull);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Fine> Fines { get; set; } // bødetilskrivelse
        public DbSet<FineLine> FineLines { get; set; }
        public DbSet<FineType> FineTypes { get; set; }





    }
}
