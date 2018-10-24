using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.DomainService
{
    public interface IFineLineRepository
    {

        FineLine Create(FineLine fineLine);
        FineLine ReadyById(int id);
        IEnumerable<FineLine> ReadAll();
        FineLine Update(FineLine fineLineUpdate);
        FineLine Delete(int id);
        FineLine ReadyByIdIncludeFineTypes(int id);

        List<FineLine> FindFineLinesByCustomerId(int customerId);

    }
}
