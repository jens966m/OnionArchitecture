using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerApp.Infrastructure.Data.Repositories
{
    public class FineRepository : IFineRepository
    {
        private readonly CustomerAppContext _context;

        public FineRepository(CustomerAppContext context)
        {
            _context = context;
        }

        public int Count()
        {
            return _context.Fines.Count();
        }

        public Fine Create(Fine fine)
        {
            _context.Attach(fine).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChangesAsync();
            return fine;
        }

        public Fine Delete(int id)
        {
            Fine fine = _context.Fines.FirstOrDefault(x => x.Id == id);
            Fine deletedFine = _context.Fines.Remove(fine).Entity;
            _context.SaveChangesAsync();
            return fine;
        }

        public IEnumerable<Fine> ReadAll(Filter filter)
        {
            if (filter == null)
            {
                return _context.Fines;
            }
            return _context.Fines.Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }

        public Fine ReadById(int id)
        {
            return _context.Fines.FirstOrDefault(fine => fine.Id == id);
        }

        public Fine ReadByIdIncludeFines(int id)
        {
            return _context.Fines.Include(x => x.FineLines).Include(x=>x.Customer).FirstOrDefault(f => f.Id == id);



        }

        public Fine Update(Fine fineUpdate)
        {
            _context.Attach(fineUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.Entry(fineUpdate).Reference(o => o.Customer).IsModified = true;
            _context.SaveChangesAsync();
            return fineUpdate;
        }
    }
}
