using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.Entity
{
    public class FineType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ListPrice { get; set; }
        public List<FineLine> FineLines { get; set; }
    }
}
