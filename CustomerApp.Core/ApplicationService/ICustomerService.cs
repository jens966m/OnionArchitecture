using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.ApplicationService
{
    public interface ICustomerService
    {
        //New Customer
        Customer NewCustomer(string firstName, string lastName, string address);

        //Create
        Customer CreateCustomer(Customer cust);

        //read
        Customer FindCustomerById(int id);
        Customer FindCustomerByIdIncludeOrders(int id);
        Customer FindCustomerByIdIncludeFines(int id);
        List<Customer> GetAllCustomers();
        List<Customer> GetAllByFirstName(string name);

        //Update
        Customer UpdateCustomer(Customer customerUpdate);

        //Delete
        Customer DeleteCustomer(int id);
       
    }
}
