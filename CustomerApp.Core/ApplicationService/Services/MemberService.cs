using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Services
{
    public class MemberService : IMemberService
    {
        readonly IMemberRepository _customerRepo;
        //readonly IOrderRepository _orderRepo;
        public MemberService( IMemberRepository customerRepository/*, IOrderRepository orderRepository*/)
        {
         _customerRepo = customerRepository;
            //_orderRepo = orderRepository;

        }
        public Member NewMember(string firstName, string lastName, string address)
        {
            var member = new Member
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
            };
            return member;
        }
        public Member CreateMember(Member memb)
        {
            if (string.IsNullOrEmpty(memb.FirstName) || string.IsNullOrEmpty(memb.LastName) || string.IsNullOrEmpty(memb.Address))
            {
                throw new InvalidDataException("Missing fields");
            }
                return _customerRepo.Create(memb);
        }

        public Member FindMemberById(int id)
        {
            return _customerRepo.ReadyById(id);
        }
        public List<Member> GetAllMembers()
        {
            return _customerRepo.ReadAll().ToList();

        }

        public List<Member> GetAllByFirstName(string name)
        {
            var list = _customerRepo.ReadAll().Where(x => x.FirstName == name);
            //list.OrderBy(x => x.FirstName = name);

            return list.ToList();
        }
       

        public Member UpdateMember(Member memberUpdate)
        {

            var member = FindMemberById(memberUpdate.Id);
            member.FirstName = memberUpdate.FirstName;
            member.LastName = memberUpdate.LastName;
            member.Address =memberUpdate.Address;
            _customerRepo.Update(member);
            return member;


        }
        public Member DeleteMember(int id)
        {
            return _customerRepo.Delete(id);
        }

        public Member FindMemberByIdIncludeFines(int id)
        {
            var customer = _customerRepo.ReadByIdIncludeFines(id);
            return customer;
        }
    }
}
