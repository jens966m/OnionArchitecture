using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.Entity
{
    public class Fine
    {
        public int Id { get; set; }
        public DateTime FineDate { get; set; }
        public DateTime PayDate { get; set; }
        public Customer Customer { get; set; }
        public List<FineLine> FineLines { get; set; }
    }
}
