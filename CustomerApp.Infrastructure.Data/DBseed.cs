using System;
using System.Collections.Generic;
using System.Text;
using CustomerApp.Core.Entity;

namespace CustomerApp.Infrastructure.Data
{
    public class DBseed
    {

        public static void SeedDB(CustomerAppContext ctx)
        {
            ctx.Database.EnsureDeleted(); // only in devMODE ! ! ! 
            ctx.Database.EnsureCreated();
            var cust1 = ctx.Members.Add(new Member()

            {
                // Id = 1,

                Address = "Bispevej",
                FirstName = "jens",
                LastName = "dideriksen",
            }).Entity;


            var cust2 = ctx.Members.Add(new Member()

            {
                // Id = 2,
                Address = "Bispevej2",
                FirstName = "jens2",
                LastName = "dideriksen2",
            }).Entity;

            var fineType1 = ctx.FineTypes.Add(new FineType()
            {
                ListPrice = 10,
                Name = "Manglende betaling"
            });
            var fineType2 = ctx.FineTypes.Add(new FineType()
            {
                ListPrice = 10,
                Name = "Ikke Fremmødt"
            });

            var fine1 = ctx.Fines.Add(new Fine()
            {
                Member = cust1,
                FineDate = DateTime.Now,
                FineType = fineType1.Entity,
                

            });

            var fine2 = ctx.Fines.Add(new Fine()
            {
                Member = cust1,
                FineDate = DateTime.Now,
                FineType = fineType2.Entity,
            });

            var fine3 = ctx.Fines.Add(new Fine()
            {
                Member = cust2,
                FineDate = DateTime.Now,
                FineType = fineType1.Entity,
            });

            //var fine2 = ctx.Fines.Add(new Fine()
            //{
            //    Customer = cust2,
            //    FineDate = DateTime.Now,
            //    FineLines = new List<FineLine>() {new FineLine() { FineType = fineType2.Entity } },

            //});

            ctx.SaveChangesAsync();
        }
    }
}
