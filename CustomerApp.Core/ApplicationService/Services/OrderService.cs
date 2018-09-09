using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order NewOrder()
        {
            return new Order();
        }

        public Order CreateOrder(Order order)
        {
            return _orderRepository.Create(order);
        }

        public Order DeleteOrder(int id)
        {
            return _orderRepository.Delete(id);
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.ReadAll().ToList();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.ReadById(id);
        }


        public Order UpdateOrder(Order updateOrder)
        {
            return _orderRepository.Update(updateOrder);
        }
    }
}
