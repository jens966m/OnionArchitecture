using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Infrastructure.Static.Data
{
    public class FakeDB
    {
        public static int Id = 1;
        public static readonly List<Customer> Customers = new List<Customer>();

        public static int OrderId = 1;
        public static readonly List<Order> Orders = new List<Order>();



    }
}
