using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerApp.Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly CustomerAppContext _context;

        public OrderRepository(CustomerAppContext context)
        {
            _context = context;
        }

        public int Count()
        {
            return _context.Orders.Count();
        }

        public Order Create(Order order)
        {
            //if (order.Customer != null && _context.ChangeTracker.Entries<Customer>().FirstOrDefault(ce=>ce.Entity.Id==order.Customer.Id)==null)
            //{
            //    _context.Attach(order.Customer);
            //}

            //Order _order = _context.Orders.Add(order).Entity;
            //_context.SaveChangesAsync();
            _context.Attach(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChangesAsync();
            return order;


        }

        public Order Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == id);
            var deletedOrder = _context.Orders.Remove(order).Entity;
            _context.SaveChangesAsync();
            return order;
        }

        public IEnumerable<Order> ReadAll(Filter filter)
        {
            if (filter == null)
            {
                return _context.Orders;
            }
            return _context.Orders.Skip((filter.CurrentPage -1 )* filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);

        }

        public Order ReadById(int id)
        {
            return _context.Orders.FirstOrDefault(order => order.Id == id);
        }

        public Order Update(Order order)
        {
            //if (order.Customer!=null && _context.ChangeTracker.Entries<Customer>().FirstOrDefault(ce=>ce.Entity.Id==order.Customer.Id)==null)
            //{
            //    _context.Attach((order.Customer));
            //}
            //else
            //{
            //    _context.Entry(order).Reference(o => o.Customer).IsModified = true;
            //}
            //var _order = _context.Orders.Update(order).Entity;
            //_context.SaveChangesAsync();
            _context.Attach(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.Entry(order).Reference(o => o.Customer).IsModified = true;
            _context.SaveChangesAsync();
            return order;
        }
    }
}
