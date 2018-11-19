using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Infrastructure.Data
{
    public class MultigroupSpaceDbContext : DbContext
    {
        public MultigroupSpaceDbContext(DbContextOptions<MultigroupSpaceDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupSpace>()
                .HasMany(u => u.Users);
            modelBuilder.Entity<User>()
                .HasMany(g => g.GroupSpaces);
                

        }
        public DbSet<GroupSpace> GroupSpaces { get; set; }
        public DbSet<User> Users { get; set; }



    }

}
