using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerApp.Infrastructure.Static.Data.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {

        public CustomerRepository()
        {
            if (FakeDB.Customers.Count >= 1) return;
            var cust1 = new Customer()
            {
                Id = FakeDB.Id++,
                FirstName = "Bob",
                LastName = "Dylan",
                Address = "BongoStreet 202"
            };
            FakeDB.Customers.Add(cust1);

            var cust2 = new Customer()
            {
                Id = FakeDB.Id++,
                FirstName = "Lars",
                LastName = "Bilde",
                Address = "Ostestrasse 202"
            };
            FakeDB.Customers.Add(cust2);
        }



        public Customer Create(Customer customer)
        {
            customer.Id = FakeDB.Id++;
            FakeDB.Customers.Add(customer);

            return customer;
        }

        public Customer Delete(int id)
        {
            var customerFound = ReadyById(id);
            if (customerFound == null) return null;

            FakeDB.Customers.Remove(customerFound);
            return customerFound;

        }

        public IEnumerable<Customer> ReadAll()
        {
            return FakeDB.Customers;


        }

        public Customer ReadyById(int id)
        {

            return FakeDB.Customers.
                Select(x => new Customer()
                {
                    Id = x.Id,
                    Address = x.Address,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                }).FirstOrDefault(x => x.Id == id);


        }

        public Customer Update(Customer customerUpdate)
        {
            var customerFromDB = this.ReadyById(customerUpdate.Id);
            if (customerFromDB != null)
            {
                
                customerFromDB.FirstName = customerUpdate.FirstName;
                customerFromDB.LastName = customerUpdate.LastName;
                customerFromDB.Address = customerUpdate.Address;
                return customerFromDB;

            }
            return null;
        }




        //remove later unitofwork
        //public Customer Update(Customer customerUpdate)
        //{
        //    var customerFromDB = this.ReadyById(customerUpdate.Id);
        //    if (customerFromDB !=null)
        //    {
        //        customerFromDB.FirstName = customerUpdate.FirstName;
        //        customerFromDB.LastName = customerUpdate.LastName;
        //        customerFromDB.Address = customerUpdate.Address;
        //        return customerFromDB;

        //    }
        //    return null;
        //}
    }
}
