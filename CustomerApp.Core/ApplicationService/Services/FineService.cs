using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Services
{
    public class FineService : IFineService
    {
        private readonly IFineRepository _fineRepository;
        private readonly IMemberRepository _customerRepository;

        public FineService(IFineRepository fineRepository, IMemberRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _fineRepository = fineRepository;
        }

        public Fine CreateFine(Fine fine)
        {
            if (fine.Member is null || fine.Member.Id <= 0)
                throw new InvalidDataException("To create a fine you need a customer");
            if (_customerRepository.ReadyById(fine.Member.Id) == null)
                throw new InvalidDataException("Fine not found");
            if (fine.FineDate == null)
                throw new InvalidDataException("Fine needs date");
            return _fineRepository.Create(fine);
        }

        public Fine DeleteFine(int id)
        {

            if (_fineRepository.ReadById(id) is null)
                throw new InvalidDataException($"Order with id: {id} does not exists");
            return _fineRepository.Delete(id);

        }

        public List<Fine> GetAllFines()
        {
            return _fineRepository.ReadAll().ToList();
        }

        public List<Fine> GetFilteredFine(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("CurrentPage and ItemsPage must be zero or more");
            }
            if ((filter.CurrentPage - 1 * filter.ItemsPrPage) >= _fineRepository.Count())
            {
                throw new InvalidDataException("Index Out of Bounds, CurrentPage is too high");
            }
            return _fineRepository.ReadAll(filter).ToList();


        }

        public Fine FindFineByIdIncludeFineType(int id)
        {
            if (_fineRepository.ReadById(id) is null)
                throw new InvalidDataException("Fine does not exists");

            return _fineRepository.ReadByIdIncludeType(id);


        }

        public Fine NewFine()
        {
            return new Fine();
        }

        public Fine UpdateFine(Fine updateFine)
        {


            if (updateFine.Member is null || updateFine.Member.Id <= 0)
                throw new InvalidDataException("To create a fine der you need a customer");
            if (_customerRepository.ReadyById(updateFine.Member.Id) == null)
                throw new InvalidDataException("Fine not found");
            if (updateFine.FineDate == null)
                throw new InvalidDataException("Fine needs date");

            return _fineRepository.Update(updateFine);

        }
    }
}
