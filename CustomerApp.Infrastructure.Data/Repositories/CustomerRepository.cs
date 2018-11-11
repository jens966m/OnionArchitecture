﻿using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerApp.Infrastructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerAppContext _context;

        public CustomerRepository(CustomerAppContext context)
        {
            _context = context;
        }
        public Member Create(Member customer)
        {
            var cust = _context.Members.Add(customer).Entity;
            _context.SaveChangesAsync();
            return cust;
        }

        public Member Delete(int id)
        {
            var member = _context.Members.FirstOrDefault(x => x.Id == id);
            var deletedMember = _context.Members.Remove(member).Entity;
            _context.SaveChangesAsync();
            return member;

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



        public Member Update(Member customerUpdate)
        {

            var cust = _context.Members.Update(customerUpdate).Entity;
            _context.SaveChangesAsync();
            return cust;
        }

        public Member ReadyByIdIncludeOrders(int id)
        {
            return _context.Members
                .Include(c => c.Orders)
                .FirstOrDefault(c => c.Id == id);
        }
        public Member ReadByIdIncludeFines(int id) 
        {
            return _context.Members
                            .Include(c => c.Fines)
                            .FirstOrDefault(c => c.Id == id);
        }

    }
}