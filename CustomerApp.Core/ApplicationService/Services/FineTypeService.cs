using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Services
{
    public class FineTypeService : IFineTypeService
    {

        readonly IFineTypeRepository _fineTypeRepo;
        public FineTypeService(IFineTypeRepository fineTypeRepo)
        {
            _fineTypeRepo = fineTypeRepo;
        }


        public FineType CreateFineType(FineType fineType)
        {
            if (string.IsNullOrEmpty(fineType.Name))
            {
                throw new InvalidDataException("Missing fields");
            }
            return _fineTypeRepo.Create(fineType);
        }

        public FineType DeleteFineType(int id)
        {
            return _fineTypeRepo.Delete(id);
        }

        public FineType FindFineTypeById(int id)
        {
            return _fineTypeRepo.ReadById(id);
        }

        public List<FineType> GetAllFineTypes()
        {
            return _fineTypeRepo.ReadAll().ToList();
        }

        public FineType NewFineType(string name, int listPrice)
        {

            var fineType = new FineType
            {
                ListPrice = listPrice,
                Name = name,
            };
            return fineType;

        }

        public FineType UpdatFineType(FineType fineTypeUpdate)
        {
            var fineType = FindFineTypeById(fineTypeUpdate.Id);
            fineType.ListPrice = fineTypeUpdate.ListPrice;
            fineType.Name = fineTypeUpdate.Name;
            return fineType;
        }
    }
}
