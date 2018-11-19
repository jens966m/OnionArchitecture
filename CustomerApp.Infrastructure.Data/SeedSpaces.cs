using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Infrastructure.Data
{
    public class SeedSpaces
    {
        public static Guid Tenant1Id = Guid.Parse("51aab199-1482-4f0d-8ff1-5ca0e7bc525a");
        public static Guid Tenant2Id = Guid.Parse("ae4e21fa-57cb-4733-b971-fdd14c4c667e");
        public static void SeedSpacesNow(MultigroupSpaceDbContext ctx)
        {
            ctx.Database.EnsureDeleted(); // only in devMODE ! ! ! 
            ctx.Database.EnsureCreated();
            ctx.GroupSpaces.Add(new GroupSpace
            {
                Id = Guid.Parse("79865406-e01b-422f-bd09-92e116a0664a"),
                DatabaseConnectionString = Tenant1Id.ToString(),
                Host = "hostString",
                Name = "jens"
            });
            ctx.GroupSpaces.Add(new GroupSpace
            {
                Id = Guid.Parse("79865406-e01b-422f-bd08-92e116a0664a"),
                DatabaseConnectionString = Tenant2Id.ToString(),
                Host = "hostString",
                Name = "peter"
            });
            ctx.SaveChanges();
        }
    }
}



