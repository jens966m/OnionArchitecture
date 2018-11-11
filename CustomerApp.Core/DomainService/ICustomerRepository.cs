using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.DomainService
{
    public interface ICustomerRepository
    {
        Member Create(Member customer);
        Member ReadyById(int id);
        IEnumerable<Member> ReadAll();
        Member Update(Member customerUpdate);
        Member Delete(int id);
        Member ReadByIdIncludeFines(int id);
    }
}
