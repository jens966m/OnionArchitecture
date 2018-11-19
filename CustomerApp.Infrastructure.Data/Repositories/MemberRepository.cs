using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerApp.Infrastructure.Data.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly CustomerAppContext _context;

        //private readonly MultigroupSpaceDbContext _context;



        public MemberRepository(CustomerAppContext context)
        {
            _context = context;
        }
        public Member Create(Member member)
        {
            var cust = _context.Members.Add(member).Entity;
            _context.SaveChangesAsync();
            return cust;
        }

        public Member Delete(int id)
        {
            var membRemoved = _context.Remove<Member>(new Member() { Id = id }).Entity;
            _context.SaveChanges();
            return membRemoved;


        }

        public IEnumerable<Member> ReadAll()
        {
            return _context.Members;
        }

        public Member ReadyById(int id)
        {
            var changeTracker = _context.ChangeTracker.Entries();
            return _context.Members.FirstOrDefault(x => x.Id == id);
        }



        public Member Update(Member memberUpdate)
        {

            var memb = _context.Members.Update(memberUpdate).Entity;
            _context.SaveChangesAsync();
            return memb;

           
        }

        public Member ReadByIdIncludeFines(int id) 
        {
            return _context.Members
                            .Include(c => c.Fines)
                            .FirstOrDefault(c => c.Id == id);
        }

    }
}