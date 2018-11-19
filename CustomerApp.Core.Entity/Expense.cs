using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.Entity
{
    public class Expense
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Member Member { get; set; }
        public DateTime BuyDate { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

    }
}
