using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.DomainService
{
    public interface IOrderRepository
    {
        Order Create(Order order);

        Order ReadById(int id);
        IEnumerable<Order> ReadAll();
        Order Update(Order order);
        Order Delete(int id);
        
    }
}
