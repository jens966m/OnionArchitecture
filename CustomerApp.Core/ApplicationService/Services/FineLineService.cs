//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using CustomerApp.Core.DomainService;
//using CustomerApp.Core.Entity;

//namespace CustomerApp.Core.ApplicationService.Services
//{
//    public class FineLineService: IFineLineService
//    {
//        readonly IFineLineRepository _fineLineRepo;

//        public FineLineService(IFineLineRepository fineLineRepository)
//        {
//            _fineLineRepo = fineLineRepository;
//        }

//        public FineLine CreateFineLine(FineLine fineLine)
//        {
//            if (fineLine.FineType==null ||fineLine.FineType==null)
//            {
//                throw new InvalidDataException("Missing fields");
//            }
//            return _fineLineRepo.Create(fineLine);
//        }

//        public FineLine DeleteFineLine(int id)
//        {
//            return _fineLineRepo.Delete(id);
//        }

//        public FineLine FindFineLineById(int id)
//        {
//            return _fineLineRepo.ReadyById(id);
//        }

//        public FineLine FindFineLineByIdIncludeFineType(int id)
//        {
//            return _fineLineRepo.ReadyByIdIncludeFineTypes(id);
//        }

//        public List<FineLine> FindFineLinesByCustomerId(int CustomerId)
//        {
//           return  _fineLineRepo.FindFineLinesByCustomerId(CustomerId);
//        }

//        public IEnumerable<FineLine> GetFineLines()
//        {
//            return _fineLineRepo.ReadAll();
//        }

//        public FineLine NewFineLine(Fine fine, FineType fineType)
//        {
//            var fineLine = new FineLine
//            {
//                Fine = fine,
//                FineType = fineType
//            };
//            return fineLine;
            
//        }

//        public FineLine UpdateFineLine(FineLine fineLineUpdate)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
