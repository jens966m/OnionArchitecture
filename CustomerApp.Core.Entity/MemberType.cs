using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.Entity
{
    public class MemberType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Member> Members { get; set; }
    }
}
