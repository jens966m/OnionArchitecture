using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerApp.Infrastructure.Data.Repositories
{
    public class FineTypeRepository : IFineTypeRepository
    {
        private readonly CustomerAppContext _context;
        public FineTypeRepository(CustomerAppContext context)
        {
            _context = context;
        }
        public int Count()
        {
           return _context.FineTypes.Count();
        }

        public FineType Create(FineType fineType)
        {
            var type = _context.FineTypes.Add(fineType).Entity;
            _context.SaveChangesAsync();
            return type;
        }

        public FineType Delete(int id)
        {
            var fineTypeRemoved = _context.Remove(new FineType() { Id = id }).Entity;
            _context.SaveChangesAsync();
            return fineTypeRemoved;
        }

        public IEnumerable<FineType> ReadAll()
        {
            return _context.FineTypes;
        }

        public FineType ReadById(int id)
        {

            var changeTracker = _context.ChangeTracker.Entries();
            return _context.FineTypes.FirstOrDefault(x => x.Id == id);
        }

        public FineType Update(FineType fineTypeUpdate)
        {
            var fineType = _context.FineTypes.Update(fineTypeUpdate).Entity;
            _context.SaveChangesAsync();
            return fineType;

        }
    }
}
