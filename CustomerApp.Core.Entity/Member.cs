using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.Entity
{
    public class Member
    {
        public int id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string address { get; set; }

        public List<Order> Orders { get; set; }

        public List<Fine> Fines { get; set; }


    }
}
