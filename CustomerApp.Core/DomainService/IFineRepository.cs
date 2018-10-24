using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.DomainService
{
    public interface IFineRepository
    {
        Fine Create(Fine fine);
        Fine ReadById(int id);
        Fine ReadByIdIncludeFines(int id);
        IEnumerable<Fine> ReadAll(Filter filter = null);
        Fine Update(Fine fineUpdate);
        Fine Delete(int id);
        int Count();
    }
}
