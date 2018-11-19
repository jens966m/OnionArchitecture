﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.Entity
{
    public class Member
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public List<Fine> Fines { get; set; }

        public MemberType MemberType { get; set; }
        //public List<Expenses> Expenses { get; set; }



    }
}
