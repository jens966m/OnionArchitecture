using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        public Order NewOrder()
        {
            return new Order();
        }

        public Order CreateOrder(Order order)
        {
            if (order.Customer is null || order.Customer.Id <= 0)
                throw new InvalidDataException("To create a order you need a customer");
            if (_customerRepository.ReadyById(order.Customer.Id) == null)
                throw new InvalidDataException("Customer not found");
            if (order.OrderDate == null)
                throw new InvalidDataException("Order needs date");

                return _orderRepository.Create(order);
        }

        public Order DeleteOrder(int id)
        {
            if (_orderRepository.ReadById(id) is null)
                throw new InvalidDataException("Order does not exists");
                return _orderRepository.Delete(id);
        }

        public List<Order> GetAllOrders()
        {
                return _orderRepository.ReadAll().ToList();
        }

        public Order GetOrderById(int id)
        {
            if (_orderRepository.ReadById(id) is null)
                throw new InvalidDataException("Order does not exists");

                return _orderRepository.ReadById(id);
        }


        public Order UpdateOrder(Order updateOrder)
        {

            if (updateOrder.Customer is null || updateOrder.Customer.Id <= 0)
                throw new InvalidDataException("To create a order you need a customer");
            if (_customerRepository.ReadyById(updateOrder.Customer.Id) == null)
                throw new InvalidDataException("Customer not found");
            if (updateOrder.OrderDate == null)
                throw new InvalidDataException("Order needs date");

            return _orderRepository.Update(updateOrder);
        }
    }
}
