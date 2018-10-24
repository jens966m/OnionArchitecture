using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.ApplicationService
{
    public interface IOrderService
    {
        //new order
        Order NewOrder();

        //create order
        Order CreateOrder(Order order);
        //Read
        Order GetOrderById(int id);
        List<Order> GetAllOrders();
        //Update
        Order UpdateOrder(Order updateOrder);
        //Delete
        Order DeleteOrder(int id);
        List<Order> GetFilteredOrder(Filter filter);
    }
}
