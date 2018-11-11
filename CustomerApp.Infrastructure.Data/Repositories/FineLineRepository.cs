//using CustomerApp.Core.DomainService;
//using CustomerApp.Core.Entity;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace CustomerApp.Infrastructure.Data.Repositories
//{
//    public class FineLineRepository : IFineLineRepository
//    {
//        private readonly CustomerAppContext _context;

//        public FineLineRepository(CustomerAppContext context)
//        {
//            _context = context;
//        }


//        public FineLine Create(FineLine fineLine)
//        {
//            var FineLine = _context.FineLines.Add(fineLine).Entity;
//            _context.SaveChangesAsync();
//            return FineLine;
//        }

//        public FineLine Delete(int id)
//        {
//            var fineLineRemoved = _context.Remove(new FineLine() { Id = id }).Entity;
//            _context.SaveChangesAsync();
//            return fineLineRemoved;
//        }

//        public List<FineLine> FindFineLinesByCustomerId(int customerId)
//        {

//            return _context.FineLines.Where(x=>x.Fine.Customer.Id== customerId).ToList(); // needs testing
//        }

//        public IEnumerable<FineLine> ReadAll()
//        {
//            return _context.FineLines;
//        }

//        public FineLine ReadyById(int id)
//        {
//            var changeTracker = _context.ChangeTracker.Entries();
//            return _context.FineLines.FirstOrDefault(x => x.Id == id);
//        }

//        public FineLine ReadyByIdIncludeFineTypes(int id)
//        {
//            return _context.FineLines
//                .Include(c => c.FineType)
//                .FirstOrDefault(c => c.Id == id);
//        }

//        public FineLine Update(FineLine fineLineUpdate)
//        {
//            var fineLine = _context.FineLines.Update(fineLineUpdate).Entity;
//            _context.SaveChangesAsync();
//            return fineLine;
//        }
//    }
//}
