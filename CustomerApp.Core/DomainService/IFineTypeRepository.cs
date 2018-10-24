using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.DomainService
{
    public interface IFineTypeRepository
    {
        FineType Create(FineType fine);
        FineType ReadById(int id);
        IEnumerable<FineType> ReadAll();
        FineType Update(FineType fineTypeUpdate);
        FineType Delete(int id);
        int Count();
    }
}
