using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.ApplicationService
{
    public interface ICustomerService
    {
        //New Customer
        Member NewCustomer(string firstName, string lastName, string address);

        //Create
        Member CreateCustomer(Member cust);

        //read
        Member FindCustomerById(int id);
        Member FindCustomerByIdIncludeFines(int id);
        List<Member> GetAllCustomers();
        List<Member> GetAllByFirstName(string name);

        //Update
        Member UpdateCustomer(Member customerUpdate);

        //Delete
        Member DeleteCustomer(int id);
       
    }
}
