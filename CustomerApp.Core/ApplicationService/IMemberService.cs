using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.ApplicationService
{
    public interface IMemberService
    {
        //New Customer
        Member NewMember(string firstName, string lastName, string address);

        //Create
        Member CreateMember(Member cust);

        //read
        Member FindMemberById(int id);
        Member FindMemberByIdIncludeFines(int id);
        List<Member> GetAllMembers();
        List<Member> GetAllByFirstName(string name);

        //Update
        Member UpdateMember(Member customerUpdate);

        //Delete
        Member DeleteMember(int id);
       
    }
}
