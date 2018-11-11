using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.ApplicationService
{
    public interface IFineService
    {
   
        //new Fine
        Fine NewFine();
        //create Fine
        Fine CreateFine(Fine fine);
        //Read Fine
        List<Fine> GetFilteredFine(Filter filter);
        Fine FindFineByIdIncludeFineType(int id);
        List<Fine> GetAllFines();
        //Update Fine
        Fine UpdateFine(Fine updateFine);
        //Delete Fine
        Fine DeleteFine(int id);

    }
}
