using CustomerApp.Core.DomainService;
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
            var cust = _context.Customers.Add(customer).Entity;
            _context.SaveChangesAsync();
            return cust;
        }

        public Member Delete(int id)
        {
            var custRemoved = _context.Remove(new Member() { Id = id }).Entity;
            _context.SaveChangesAsync();
            return custRemoved;
        }

        public IEnumerable<Member> ReadAll()
        {
            return _context.Customers;
        }

        public Member ReadyById(int id)
        {
            var changeTracker = _context.ChangeTracker.Entries();
            return _context.Customers.FirstOrDefault(x => x.Id == id);
        }



        public Member Update(Member customerUpdate)
        {

            var cust = _context.Customers.Update(customerUpdate).Entity;
            _context.SaveChangesAsync();
            return cust;
        }

        public Member ReadyByIdIncludeOrders(int id)
        {
            return _context.Customers
                .Include(c => c.Orders)
                .FirstOrDefault(c => c.Id == id);
        }
        public Member ReadByIdIncludeFines(int id) 
        {
            return _context.Customers
                            .Include(c => c.Fines)
                            .FirstOrDefault(c => c.Id == id);
        }

    }
}