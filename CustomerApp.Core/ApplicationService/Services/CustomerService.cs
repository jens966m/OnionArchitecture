using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Services
{
    public class CustomerService : ICustomerService
    {
        readonly ICustomerRepository _customerRepo;
        public CustomerService( ICustomerRepository customerRepository)
        {
         _customerRepo = customerRepository;

        }
        public Customer NewCustomer(string firstName, string lastName, string address)
        {
            var customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
            };
            return customer;
        }
        public Customer CreateCustomer(Customer cust)
        {
            return _customerRepo.Create(cust);


        }

        public Customer FindCustomerById(int id)
        {
            return _customerRepo.ReadyById(id);
        }
        public List<Customer> GetAllCustomers()
        {
            return _customerRepo.ReadAll().ToList();

        }

        public List<Customer> GetAllByFirstName(string name)
        {
            var list = _customerRepo.ReadAll().Where(x => x.FirstName == name);
            //list.OrderBy(x => x.FirstName = name);

            return list.ToList();
        }
       

        public Customer UpdateCustomer(Customer customerUpdate)
        {

            var customer = FindCustomerById(customerUpdate.Id);
            customer.FirstName = customerUpdate.FirstName;
            customer.LastName = customerUpdate.LastName;
            customer.Address =customerUpdate.Address;
            return customer;


        }
        public Customer DeleteCustomer(int id)
        {
            return _customerRepo.Delete(id);
        }
    }
}
