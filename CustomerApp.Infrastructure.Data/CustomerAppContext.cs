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
            modelBuilder.Entity<Fine>()
                .HasOne(f => f.Member)
                .WithMany(c => c.Fines)
                .OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<Fine>()
            //    .HasOne(x => x.FineType)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<Member>()
            //    .HasMany(f => f.Fines)
            //    .WithOne(m => m.Member)
            //    .OnDelete(DeleteBehavior.Cascade);

        }
        public DbSet<Member> Members { get; set; }
        //public DbSet<Order> Orders { get; set; } // needs to be deleted
        public DbSet<Fine> Fines { get; set; } // bødetilskrivelse
        //public DbSet<FineLine> FineLines { get; set; }
        public DbSet<FineType> FineTypes { get; set; }





    }
}
