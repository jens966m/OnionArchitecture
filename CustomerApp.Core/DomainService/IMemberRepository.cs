using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.DomainService
{
    public interface IMemberRepository
    {
        Member Create(Member member);
        Member ReadyById(int id);
        IEnumerable<Member> ReadAll();
        Member Update(Member memberUpdate);
        Member Delete(int id);
        Member ReadByIdIncludeFines(int id);
    }
}
