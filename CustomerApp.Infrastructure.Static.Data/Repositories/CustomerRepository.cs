﻿using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Infrastructure.Static.Data.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        static int id = 1;
        private List<Customer> _customers = new List<Customer>();

        public Customer Create(Customer customer)
        {
            customer.Id = id++;
            _customers.Add(customer);

            return customer;
        }

        public Customer Delete(int id)
        {
            var customerFound = this.ReadyById(id);
            if (customerFound!=null)
            {
                _customers.Remove(customerFound);
            }
            return customerFound;

        }

        public IEnumerable<Customer> ReadAll()
        {
            return _customers;
        }

        public Customer ReadyById(int id)
        {
            foreach (var customer in _customers)
            {
                if (customer.Id==id)
                {
                    return customer;

                }
                
            }
            return null;

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
