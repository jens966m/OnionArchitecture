using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.ApplicationService
{
    public interface IFineTypeService
    {
        //New Customer
        FineType NewFineType(string name, int listPrice);
        //Create
        FineType CreateFineType(FineType fineType);
        //read
        FineType FindFineTypeById(int id);
        List<FineType> GetAllFineTypes();
        //Update
        FineType UpdatFineType(FineType fineTypeUpdate);
        //Delete
        FineType DeleteFineType(int id);
    }
}
